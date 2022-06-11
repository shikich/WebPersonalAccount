using Microsoft.AspNetCore.Mvc;
using WebClient_AP.Models;
using WebClient_AP.Models.View;

namespace WebClient_AP.Controllers
{
    public class PersonalAccountController : Controller
    {
        //get
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PersonalAccount pa)
        {
            using (var client = new HttpClient())
            {
                pa.DateOpen = DateTime.Today;

                client.BaseAddress = new Uri("https://localhost:7288/api/PersonalAccount/Create");
                var createTask = client.PostAsJsonAsync("Create", pa);
                createTask.Wait();

                var resultCreate = createTask.Result;
                if (resultCreate.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }
                return View(pa);
            }
        }
        //get
        public IActionResult List()
        {
            IEnumerable<PersonalAccount>? accs = null;
            List<PersonalAccount_GroupVM> accsgr = new List<PersonalAccount_GroupVM>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7288/api/");
                var responseTask = client.GetAsync("PersonalAccount/Read");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var read = result.Content.ReadAsAsync<IList<PersonalAccount>>();
                    read.Wait();
                    accs = read.Result;
                    foreach (var acc in accs)
                    {
                        if (acc.IdGroup != null)
                        {
                            var quantity = client.GetAsync($"PersonalAccount/Quantity/{acc.IdGroup}");
                            quantity.Wait();
                            var resultQuantity = quantity.Result;
                            if (resultQuantity.IsSuccessStatusCode)
                            {
                                var count = resultQuantity.Content.ReadAsAsync<int>();
                                count.Wait();
                                var countResidents = count.Result;
                                PersonalAccount_GroupVM paVm = new PersonalAccount_GroupVM();
                                paVm.IdGroup = acc.IdGroup;
                                paVm.IdAccount = acc.IdAccount;
                                paVm.FirstName = acc.FirstName;
                                paVm.LastName = acc.LastName;
                                paVm.MiddleName = acc.MiddleName;
                                paVm.City = acc.City;
                                paVm.Street = acc.Street;
                                paVm.Building = acc.Building;
                                paVm.AppartmentId = acc.AppartmentId;
                                paVm.DateOpen = acc.DateOpen;
                                paVm.DateClose = acc.DateClose;
                                paVm.IdGroup = acc.IdGroup;
                                paVm.Quantity = countResidents;
                                accsgr.Add(paVm);
                            }
                            else
                            {
                                accs = null;
                                ModelState.AddModelError(String.Empty, "- Server error occured, List of Personal Accounts. Quantity -");
                            }
                        }
                        else
                        {
                            PersonalAccount_GroupVM paVm = new PersonalAccount_GroupVM();
                            paVm.IdGroup = acc.IdGroup;
                            paVm.IdAccount = acc.IdAccount;
                            paVm.FirstName = acc.FirstName;
                            paVm.LastName = acc.LastName;
                            paVm.MiddleName = acc.MiddleName;
                            paVm.City = acc.City;
                            paVm.Street = acc.Street;
                            paVm.Building = acc.Building;
                            paVm.AppartmentId = acc.AppartmentId;
                            paVm.DateOpen = acc.DateOpen;
                            paVm.DateClose = acc.DateClose;
                            paVm.IdGroup = acc.IdGroup;
                            paVm.Quantity = 0;
                            accsgr.Add(paVm);
                        }
                    }
                }
                else
                {
                    accs = null;
                    ModelState.AddModelError(String.Empty, "- Server error occured, List of Personal Accounts -");
                }
            }
            return View(accsgr);
        }
        //get
        public IActionResult ListSearch(string search)
        {
            IEnumerable<PersonalAccount>? accs = null;
            List<PersonalAccount_GroupVM> accsgr = new List<PersonalAccount_GroupVM>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7288/api/");
                var responseSearch = client.GetAsync("PersonalAccount/Read");
                responseSearch.Wait();

                var resultSearch = responseSearch.Result;

                if (resultSearch.IsSuccessStatusCode)
                {
                    var read = resultSearch.Content.ReadAsAsync<IList<PersonalAccount>>();
                    read.Wait();
                    accs = read.Result;
                    foreach (var acc in accs)
                    {
                        if (acc.IdGroup != null)
                        {
                            var quantity = client.GetAsync($"PersonalAccount/Quantity/{acc.IdGroup}");
                            quantity.Wait();
                            var resultQuantity = quantity.Result;
                            if (resultQuantity.IsSuccessStatusCode)
                            {
                                var count = resultQuantity.Content.ReadAsAsync<int>();
                                count.Wait();
                                var countResidents = count.Result;
                                PersonalAccount_GroupVM paVm = new PersonalAccount_GroupVM();
                                paVm.IdGroup = acc.IdGroup;
                                paVm.IdAccount = acc.IdAccount;
                                paVm.FirstName = acc.FirstName;
                                paVm.LastName = acc.LastName;
                                paVm.MiddleName = acc.MiddleName;
                                paVm.City = acc.City;
                                paVm.Street = acc.Street;
                                paVm.Building = acc.Building;
                                paVm.AppartmentId = acc.AppartmentId;
                                paVm.DateOpen = acc.DateOpen;
                                paVm.DateClose = acc.DateClose;
                                paVm.IdGroup = acc.IdGroup;
                                paVm.Quantity = countResidents;
                                accsgr.Add(paVm);
                            }
                            else
                            {
                                accs = null;
                                ModelState.AddModelError(String.Empty, "- Server error occured, List of Personal Accounts. Quantity -");
                            }
                        }
                        else
                        {
                            PersonalAccount_GroupVM paVm = new PersonalAccount_GroupVM();
                            paVm.IdGroup = acc.IdGroup;
                            paVm.IdAccount = acc.IdAccount;
                            paVm.FirstName = acc.FirstName;
                            paVm.LastName = acc.LastName;
                            paVm.MiddleName = acc.MiddleName;
                            paVm.City = acc.City;
                            paVm.Street = acc.Street;
                            paVm.Building = acc.Building;
                            paVm.AppartmentId = acc.AppartmentId;
                            paVm.DateOpen = acc.DateOpen;
                            paVm.DateClose = acc.DateClose;
                            paVm.IdGroup = acc.IdGroup;
                            paVm.Quantity = 0;
                            accsgr.Add(paVm);
                        }
                    }
                }
                else
                {
                    accs = null;
                    ModelState.AddModelError(String.Empty, "- Server error occured, List Search of Personal Accounts -");
                }
            }
            if (!string.IsNullOrWhiteSpace(search))
            {
                accsgr = accsgr.Where(x => x.FirstName.Contains(search) 
                                    || x.MiddleName.Contains(search)
                                    || x.LastName.Contains(search)
                                    || x.City.Contains(search)
                                    || x.Street.Contains(search)
                                    || x.Building.Contains(search)
                                    || x.AppartmentId.Contains(search)
                                    || x.DateOpen.ToString().Contains(search)
                                    || x.DateClose.ToString().Contains(search)).ToList();
            }
            return View(accsgr);
        }
        //get
        public IActionResult Details(int accId)
        {
            PersonalAccount? acc = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7288/api/");
                var responseTask = client.GetAsync($"PersonalAccount/Update/{accId}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var read = result.Content.ReadAsAsync<PersonalAccount>();
                    read.Wait();
                    acc = read.Result;
                }
                else
                {
                    acc = null;
                    ModelState.AddModelError(String.Empty, "- Server error occured, Details -");
                }
            }
            return View(acc);
        }
        [HttpPost]
        public IActionResult Details(PersonalAccount pa)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7288/api/PersonalAccount/Update");
                var putTask = client.PutAsJsonAsync("Update", pa);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }
                return View(pa);
            }
        }
        //get
        public IActionResult Residents(int accId)
        {
            PersonalAccount? acc = null;
            PersonalAccount_Group_PersonVM all = new PersonalAccount_Group_PersonVM();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7288/api/");
                var responseTask = client.GetAsync($"PersonalAccount/Update/{accId}");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var read = result.Content.ReadAsAsync<PersonalAccount>();
                    read.Wait();
                    acc = read.Result;
                    all.IdAccount = acc.IdAccount;
                    all.FirstName = acc.FirstName;
                    all.LastName = acc.LastName;
                    all.MiddleName = acc.MiddleName;
                    all.City = acc.City;
                    all.Street = acc.Street;
                    all.Building = acc.Building;
                    all.AppartmentId = acc.AppartmentId;
                    all.DateOpen = acc.DateOpen;
                    all.DateClose = acc.DateClose;
                    all.IdGroup = acc.IdGroup;
                    List<ToGroupPerson> toGroups = new List<ToGroupPerson>();

                    var responseTaskGroup = client.GetAsync($"Group/Read");
                    responseTaskGroup.Wait();
                    var resultGroup = responseTaskGroup.Result;
                    if (resultGroup.IsSuccessStatusCode)
                    {
                        var readGroup = resultGroup.Content.ReadAsAsync<List<OneGroup>>();
                        readGroup.Wait();
                        var groups = readGroup.Result.Where(x => x.IdGroup == all.IdGroup);


                        var responseTaskPerson = client.GetAsync($"Person/Read");
                        responseTaskPerson.Wait();
                        var resultPerson = responseTaskPerson.Result;
                        if (resultPerson.IsSuccessStatusCode)
                        {
                            var readPerson = resultPerson.Content.ReadAsAsync<List<Person>>();
                            readPerson.Wait();
                            var persons = readPerson.Result;

                            foreach (var gr in groups)
                            {
                                foreach (var pr in persons)
                                {
                                    if (groups.Select(x => x).Any(z => z.IdPerson == pr.IdPerson) && !toGroups.Exists(x => x.IdPerson == pr.IdPerson))
                                    {
                                        ToGroupPerson toGroupPerson = new ToGroupPerson();
                                        toGroupPerson.IdPerson = pr.IdPerson;
                                        toGroupPerson.FirstName = pr.FirstName;
                                        toGroupPerson.LastName = pr.LastName;
                                        toGroupPerson.MiddleName = pr.MiddleName;
                                        toGroupPerson.DateSince = pr.DateSince;
                                        toGroupPerson.DateTo = pr.DateTo;
                                        toGroupPerson.isLiving = true;
                                        toGroups.Add(toGroupPerson);
                                    }
                                    if (!toGroups.Exists(x => x.IdPerson == pr.IdPerson))
                                    {
                                        ToGroupPerson toGroupPerson = new ToGroupPerson();
                                        toGroupPerson.IdPerson = pr.IdPerson;
                                        toGroupPerson.FirstName = pr.FirstName;
                                        toGroupPerson.LastName = pr.LastName;
                                        toGroupPerson.MiddleName = pr.MiddleName;
                                        toGroupPerson.DateSince = pr.DateSince;
                                        toGroupPerson.DateTo = pr.DateTo;
                                        toGroupPerson.isLiving = false;
                                        toGroups.Add(toGroupPerson);
                                    }
                                }
                            }   
                            if (groups.ToArray().Count() == 0)
                            {
                                foreach (var pr in persons)
                                {
                                    ToGroupPerson toGroupPerson = new ToGroupPerson();
                                    toGroupPerson.IdPerson = pr.IdPerson;
                                    toGroupPerson.FirstName = pr.FirstName;
                                    toGroupPerson.LastName = pr.LastName;
                                    toGroupPerson.MiddleName = pr.MiddleName;
                                    toGroupPerson.DateSince = pr.DateSince;
                                    toGroupPerson.DateTo = pr.DateTo;
                                    toGroupPerson.isLiving = false;
                                    toGroups.Add(toGroupPerson);
                                }
                            }
                            all.GroupPersons = toGroups;
                        }
                        else
                        {
                            acc = null;
                            ModelState.AddModelError(String.Empty, "- Server error occured, Person -");
                        }
                    }
                    else
                    {
                        acc = null;
                        ModelState.AddModelError(String.Empty, "- Server error occured, Groups -");
                    }
                }
                else
                {
                    acc = null;
                    ModelState.AddModelError(String.Empty, "- Server error occured, Residents -");
                }
            }
            return View(all);
        }
        [HttpPost]
        public IActionResult Residents(PersonalAccount_Group_PersonVM all)
        {
            using (var client = new HttpClient())
            {
                PersonalAccount pa = new PersonalAccount();
                pa.IdAccount = all.IdAccount;
                pa.FirstName = all.FirstName;
                pa.LastName = all.LastName;
                pa.MiddleName = all.MiddleName;
                pa.City = all.City;
                pa.Street = all.Street;
                pa.Building = all.Building;
                pa.AppartmentId = all.AppartmentId;
                pa.DateClose = all.DateClose;
                pa.DateOpen = all.DateOpen;
                pa.IdGroup = all.IdGroup;

                client.BaseAddress = new Uri("https://localhost:7288/api/");  

                if (!all.GroupPersons.Any(x => x.isLiving == true) && pa.IdGroup == null)
                {
                    pa.IdGroup = null;
                }
                else
                {
                    if (pa.IdGroup == null)
                    {    
                        var getGroupRead = client.GetAsync("Group/Read");
                        getGroupRead.Wait();
                        var resultGetGroup = getGroupRead.Result;
                        if (resultGetGroup.IsSuccessStatusCode)
                        {
                            var readGroup = resultGetGroup.Content.ReadAsAsync<List<OneGroup>>();
                            readGroup.Wait();
                            pa.IdGroup = readGroup.Result.Select(x => x.IdGroup).Max() + 1;
                        }
                    }
                }
                var putTask = client.PutAsJsonAsync("PersonalAccount/Update", pa);
                putTask.Wait();
                var result = putTask.Result;              

                if (result.IsSuccessStatusCode)
                { 
                    var deleteTask = client.DeleteAsync($"Group/Delete/{pa.IdGroup}");
                    deleteTask.Wait();
                    var resultDelete = deleteTask.Result;
                    if (resultDelete.IsSuccessStatusCode)
                    {
                        foreach (var group in all.GroupPersons)
                        {
                            if (group.isLiving)
                            {
                                OneGroup og = new OneGroup();
                                og.IdGroup = (int)pa.IdGroup;
                                og.IdPerson = group.IdPerson;
                                var createGroup = client.PostAsJsonAsync("Group/Create", og);
                                createGroup.Wait();
                                var resultGroup = createGroup.Result;
                                if (resultGroup.IsSuccessStatusCode)
                                {
                                    var getPerson = client.GetAsync($"Person/Update/{og.IdPerson}");
                                    getPerson.Wait();
                                    var resultGetPerson = getPerson.Result;
                                    if (resultGetPerson.IsSuccessStatusCode)
                                    {
                                        var readPerson = resultGetPerson.Content.ReadAsAsync<Person>();
                                        readPerson.Wait();
                                        Person p = readPerson.Result;
                                        if (p.DateSince == null)
                                        {
                                            p.DateSince = DateTime.UtcNow;
                                            p.DateTo = null;
                                        }
                                        var putPerson = client.PutAsJsonAsync("Person/Update", p);
                                        putPerson.Wait();
                                        if (putPerson.IsCanceled)
                                        {
                                            ModelState.AddModelError(String.Empty, "- Server error occured, Put Person -");
                                        }
                                    }
                                    else
                                    {
                                        ModelState.AddModelError(String.Empty, "- Server error occured, Get Person -");
                                    }
                                }
                                else
                                {
                                    ModelState.AddModelError(String.Empty, "- Server error occured, Create Group -");
                                }
                            }
                            else
                            {
                                var getPerson = client.GetAsync($"Person/Update/{group.IdPerson}");
                                getPerson.Wait();
                                var resultGetPerson = getPerson.Result;
                                if (resultGetPerson.IsSuccessStatusCode)
                                {
                                    var readPerson = resultGetPerson.Content.ReadAsAsync<Person>();
                                    readPerson.Wait();
                                    Person p = readPerson.Result;
                                    if (p.DateSince != null)
                                    {
                                        p.DateTo = DateTime.UtcNow;
                                    }
                                    var putPerson = client.PutAsJsonAsync("Person/Update", p);
                                    putPerson.Wait();
                                    if (putPerson.IsCanceled)
                                    {
                                        ModelState.AddModelError(String.Empty, "- Server error occured, Put Person -");
                                    }
                                }
                                else
                                {
                                    ModelState.AddModelError(String.Empty, "- Server error occured, Get Person -");
                                }
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(String.Empty, "- Server error occured, Delete Group -");
                    }
                    return RedirectToAction("List");
                }
                return View(all);
            }
        }
        [HttpPost]
        public IActionResult CloseAP(int paVmID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7288/api/");
                var responseTask = client.GetAsync($"PersonalAccount/Update/{paVmID}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var read = result.Content.ReadAsAsync<PersonalAccount>();
                    read.Wait();
                    PersonalAccount acc = read.Result;
                    acc.DateClose = DateTime.Today;
                    var putTask = client.PutAsJsonAsync("PersonalAccount/Update", acc);
                    putTask.Wait();
                    var resultPut = putTask.Result;
                    if (resultPut.IsSuccessStatusCode)
                    {
                        return RedirectToAction("List");
                    }
                    else
                    {
                        ModelState.AddModelError(String.Empty, "- Server error occured, CloseAP Put AP -");
                    }
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "- Server error occured, CloseAP Get AP -");
                }
            }     
            return RedirectToAction("List");
        }
    }
}
