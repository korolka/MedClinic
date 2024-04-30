using MedClinic.Models;
using MedClinicBL.LogInService;
using MedClinicBL.Services;
using MedClinicDAL.IRepository;
using MedClinicDAL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace MedClinic.Controllers
{
    public class HomeController : Controller
    {
        ISpecializationRepository specialization;
        IDoctorRepository doctorRep;
        ISlotCreator slotCreator;
        ISlotRepository slotRepository;
        IClinicRepository clinicRepository;
        IUserRepository userRepository;

        public HomeController(IUserRepository userRepository, ISpecializationRepository specialization, IDoctorRepository doctorRep, ISlotCreator slotCreator, ISlotRepository slotRepository, IClinicRepository clinicRepository)
        {
            this.doctorRep = doctorRep;
            this.userRepository = userRepository;
            this.specialization = specialization;
            this.slotCreator = slotCreator;
            this.slotRepository = slotRepository;
            this.clinicRepository = clinicRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "User,Admin")]
        public IActionResult Generic()
        {
            ViewBag.Title = "Generic";
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateDocAndSlot()
        {
            IEnumerable<Specialization> specializations = await specialization.GetAll();
            ViewBag.Spec = new SelectList(specializations, "ID", "NameOfSpecialization");
            IEnumerable<Clinic> clinic = await clinicRepository.GetAll();
            ViewBag.ClinicAddress = new SelectList(clinic, "ID", "Address");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDocAndSlot(AddDoctorBindingModel model)
        {
            if (ModelState.IsValid)
            {
                Doctor doctor = await doctorRep.GetByPredicate(d => d.Name == model.Name && d.SurName == model.SurName && d.PassportId == model.PassportId);
                if (doctor == null)
                {
                    doctor = new Doctor()
                    {
                        ID = Guid.NewGuid(),
                        Name = model.Name,
                        MiddleName = model.MiddleName,
                        SurName = model.SurName,
                        PassportId = model.PassportId,
                        BirthDay = model.BirthDay,
                        CostForOneVisit = model.CostForOneVisit,
                        DayStartOfWork = model.DayStartOfWork,
                        LinkPhoto = model.LinkPhoto,
                        SpecializationId = model.Specialization,
                        ClinicId = model.Clinic,
                        Slots = new List<Slot>(),
                    };
                    await doctorRep.Add(doctor);
                    List<DateTime> dates = model.SelectedDays;
                    List<Slot> slots = new List<Slot>();
                    foreach (var day in dates)
                    {
                        slots.AddRange(await slotCreator.GenerateSlots(doctor, day, slotRepository));
                    }
                    await slotRepository.AddRangeAsync(slots);
                    return View("Index");
                }
                ModelState.AddModelError("", "This peson is exist");
            }
            IEnumerable<Specialization> specializations = await specialization.GetAll();
            ViewBag.Spec = new SelectList(specializations, "ID", "NameOfSpecialization");
            return View(model);
        }

        public IActionResult AddSlots()
        {
            List<Doctor> docs = doctorRep.GetAll().Result.ToList();
            var docWithFullName = docs.Select(d => new
            {
                ID = d.ID,
                FullName = d.Name + " " + d.SurName,
            }).ToList();
            ViewBag.Docs = new SelectList(docWithFullName, "ID", "FullName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSlots(DoctorChooseBindingModel choosenDoc)
        {
            if (ModelState.IsValid)
            {
                Doctor doc = await doctorRep.GetById(choosenDoc.ChoosenDoctor);
                List<Slot> slots = new List<Slot>();
                foreach (var day in choosenDoc.SelectedDays)
                {
                    slots.AddRange(await slotCreator.GenerateSlots(doc, day, slotRepository));
                }
                await slotRepository.AddRangeAsync(slots);
            }
            return View("Index");
        }


        [HttpPost]
        public async Task<IActionResult> SearchDoc(SearchDocBindingModel searchDoc)
        {
            if (ModelState.IsValid)
            {
                var doctors = await doctorRep.GetAll();
                List<Specialization> specList = specialization.GetAll().Result.ToList();
                searchDoc.SurNameOrSpecialization.ToLower();
                var res = from specialWord in specList
                          where specialWord.NameOfSpecialization.ToLower() == searchDoc.SurNameOrSpecialization.ToLower()
                          select specialWord;
                if (res.Any())
                {
                    doctors = doctors.Where(d => d.Specialization.NameOfSpecialization.ToLower() == searchDoc.SurNameOrSpecialization.ToLower()).ToList();
                    return View("SearchDoc", doctors);
                }

                var res2 = doctors.Where(d => d.SurName.ToLower() == searchDoc.SurNameOrSpecialization.ToLower()).ToList();
                if (res2.Any())
                {
                    return View("SearchDoc", res2);
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AllDays(string id)
        {
            Guid.TryParse(id, out Guid GuidId);
            var doctor = await doctorRep.GetAllByPredicate(d => d.ID == GuidId);
            return View(doctor.FirstOrDefault());
        }

        public async Task<IActionResult> CompleteReg(string doctorId, string slotId)
        {

            Guid.TryParse(slotId, out Guid GuidSlotId);
            Guid.TryParse(doctorId, out Guid GuidDoctorId);
            Doctor doctor = await doctorRep.GetById(GuidDoctorId);
            Slot slot = await slotRepository.GetById(GuidSlotId);
            MedClinicDAL.Models.User user = await userRepository.GetByPredicate(u => u.Email == User.Identity.Name);//todo create user rep interface bu dep. inj

            Record record = new Record()
            {
                Doctor = doctor,
                Slot = slot,
                SlotId = slot.ID,
                User= user,
            };
            return View(record);
        }



    }
}
