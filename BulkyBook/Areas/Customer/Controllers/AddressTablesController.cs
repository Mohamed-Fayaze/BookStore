using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using BulkyBook.DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BulkyBook.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class AddressTablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressTablesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: AddressTables
        public async Task<IActionResult> Index(int? businessid, string category)
        {
            //var claimsIdentity = (ClaimsIdentity)User.Identity;
            //var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //ContactVM contactVM = new ContactVM();
            //contactVM.addressTable.UserId = claim.Value;
            ViewData["category"] = category;
            List<SelectListItem> addresstype = new List<SelectListItem>();
            addresstype.Add(new SelectListItem() { Text = "Home", Value = "Home" });
            addresstype.Add(new SelectListItem() { Text = "Business", Value = "Business" });
            ViewBag.Addresstype = new SelectList(addresstype, "Value", "Text");
            ContactVM contactVM = new ContactVM();

            //var address = await _context.AddressTables.ToListAsync();
            //var address = _context.AddressTables.All(s => s.UserId == claim.Value).t;
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var address = (from a in _context.AddressTables where a.UserId == claim.Value select a).ToList();
            if (businessid != null)
            {
                address = address.Where(s => s.BusinessId == businessid).ToList();
            }
            else
            {
                address = address.Where(s => s.BusinessId == null).ToList();
            }
            if (address.Count > 0)
            {
                return await Edit(address[0].AddressId);
            }
            else
            {
                //IEnumerable<MobileTable> mobileTables = Enumerable.Empty<MobileTable>();
                //MobileTable mobileTable = new MobileTable();
                //contactVM.MobileTable = mobileTables.Append(mobileTable).ToList();
                //IEnumerable<LandlineTable> landlineTables = Enumerable.Empty<LandlineTable>();
                //LandlineTable landlineTable = new LandlineTable();
                //contactVM.LandlineTable = landlineTables.Append(landlineTable).ToList();
                //IEnumerable<EmailTable> emailTables = Enumerable.Empty<EmailTable>();
                //EmailTable emailTable = new EmailTable();
                //contactVM.EmailTable = emailTables.Append(emailTable).ToList();
                //IEnumerable<SocialTable> socialTables = Enumerable.Empty<SocialTable>();
                //SocialTable socialTable = new SocialTable();
                //contactVM.SocialTable = socialTables.Append(socialTable).ToList();

                contactVM.MobileTable = Enumerable.Empty<Mobile>().ToList();
                contactVM.LandlineTable = Enumerable.Empty<Landline>().ToList();
                contactVM.EmailTable = Enumerable.Empty<Email>().ToList();
                contactVM.SocialTable = Enumerable.Empty<Social>().ToList();


                //var mobile = await _context.MobileTables.ToListAsync();
                //var landline = await _context.LandlineTables.ToListAsync();
                //var email = await _context.EmailTables.ToListAsync();
                //var social = await _context.SocialTables.ToListAsync();
                //var location = await _context.LocationTables.ToListAsync();
                //contactVM.AddressTable = address;
                //contactVM.MobileTable = mobile;
                //contactVM.LandlineTable = landline;
                //contactVM.EmailTable = email;
                //contactVM.SocialTable = social;
                //contactVM.LocationTable = location;


                //var addre = await _context.AddressTables.FindAsync(AddressId);
                //var addre1 = await _context.MobileTables.FirstOrDefaultAsync(s => s.AddressId == AddressId);
                //var addre2 = await _context.LandlineTables.FirstOrDefaultAsync(s => s.AddressId == AddressId);
                //var addre3 = await _context.EmailTables.FirstOrDefaultAsync(s => s.AddressId == AddressId);
                //var addre4 = await _context.SocialTables.FirstOrDefaultAsync(s => s.AddressId == AddressId);
                //var addre5 = await _context.LocationTables.FirstOrDefaultAsync(s => s.AddressId == AddressId);
                //ContactVM contactVM = new ContactVM();
                //contactVM.AddressTable = await _context.AddressTables.ToListAsync();
                contactVM.AddressTable = (from a in _context.AddressTables where a.UserId == claim.Value select a).ToList();
                if (businessid != null)
                {
                    contactVM.AddressTable = contactVM.AddressTable.Where(s => s.BusinessId == businessid).ToList();
                }
                else
                {
                    contactVM.AddressTable = contactVM.AddressTable.Where(s => s.BusinessId == null).ToList();
                }
                //contactVM.MobileTable = await _context.MobileTables.ToListAsync();
                //contactVM.LandlineTable = await _context.LandlineTables.ToListAsync();
                //contactVM.EmailTable = await _context.EmailTables.ToListAsync();
                //contactVM.SocialTable = await _context.SocialTables.ToListAsync();
                //contactVM.LocationTable = await _context.LocationTables.ToListAsync();

                //contactVM.addressTable = addre;
                //contactVM.mobileTable = addre1;
                //contactVM.landlineTable = addre2;
                //contactVM.emailTable = addre3;
                //contactVM.socialTable = addre4;
                //contactVM.locationTable = addre5;

                contactVM.addressTable = new Address();
                if (businessid != null)
                {
                    contactVM.addressTable.BusinessId = businessid;
                }
                //MobileTable mobileTable = new MobileTable();
                //contactVM.MobileTable = new MobileTable();

                //contactVM.landlineTable = new LandlineTable();
                //contactVM.emailTable = new EmailTable();
                //contactVM.locationTable = new LocationTable();
                //contactVM.socialTable = new SocialTable();
            }

            //msg = "Record Created";
            //return View(contactVM);

            return View(contactVM);
        }

        // GET: AddressTables/Details/5
        //public async Task<IActionResult> Details(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var addressTable = await _context.AddressTables
        //        .FirstOrDefaultAsync(m => m.AddressId == id);
        //    if (addressTable == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(addressTable);
        //}

        // GET: AddressTables/Create
        public IActionResult Create()
        {
            ContactVM contactVM = new ContactVM()
            {
                MobileTable = new List<Mobile>()
            };
            return View(contactVM);
        }

        // POST: AddressTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactVM contactVM, string category)
        {
            try
            {
                ViewData["category"] = category;
                var exista = await _context.AddressTables.AnyAsync(x => x.AddressId == contactVM.addressTable.AddressId);
                if (exista)
                {
                    List<SelectListItem> addresstype = new List<SelectListItem>();
                    addresstype.Add(new SelectListItem() { Text = "Home", Value = "Home" });
                    addresstype.Add(new SelectListItem() { Text = "Business", Value = "Business" });
                    ViewBag.Addresstype = new SelectList(addresstype, "Value", "Text");
                    var addre = await _context.AddressTables.FindAsync(contactVM.addressTable.AddressId);
                    //var addre = await _context.AddressTables.FindAsync(from a in _context.AddressTables where a.AddressId == contactVM.addressTable.AddressId orderby a.AddressId select a);
                    var addre1 = (from a in _context.MobileTables where a.AddressId == contactVM.addressTable.AddressId orderby a.MobileId select a);
                    //var addre1 =  _context.MobileTables.FirstOrDefault(s => s.AddressId == contactVM.addressTable.AddressId);
                    var addre2 = (from a in _context.LandlineTables where a.AddressId == contactVM.addressTable.AddressId orderby a.LandlineId select a);
                    var addre3 = (from a in _context.EmailTables where a.AddressId == contactVM.addressTable.AddressId orderby a.EmailAddressId select a);
                    var addre4 = (from a in _context.SocialTables where a.AddressId == contactVM.addressTable.AddressId orderby a.SocialId select a);
                    var addre5 = await _context.LocationTables.FirstOrDefaultAsync(s => s.AddressId == contactVM.addressTable.AddressId);

                    addre.CityTown = contactVM.addressTable.CityTown;
                    addre.AddressField = contactVM.addressTable.AddressField;
                    addre.AddressType = contactVM.addressTable.AddressType;
                    addre.StateProvinceRegion = contactVM.addressTable.StateProvinceRegion;
                    addre.AreaStreet = contactVM.addressTable.AreaStreet;
                    addre.Country = contactVM.addressTable.Country;
                    addre.HouseNo = contactVM.addressTable.HouseNo;
                    addre.Landmark = contactVM.addressTable.Landmark;
                    addre.Pincode = contactVM.addressTable.Pincode;


                    if (addre1 != null)
                    {
                        _context.RemoveRange(addre1);
                    }
                    foreach (var item in contactVM.MobileTable)
                    {
                        item.AddressId = contactVM.addressTable.AddressId;
                        await _context.AddAsync(item);
                    }

                    if (addre2 != null)
                    {
                        _context.RemoveRange(addre2);
                    }
                    foreach (var item in contactVM.LandlineTable)
                    {
                        item.AddressId = contactVM.addressTable.AddressId;
                        if (item.LandlineNo == null)
                        {
                            contactVM.LandlineTable.Remove(item);
                        }
                    }
                    await _context.AddRangeAsync(contactVM.LandlineTable);



                    if (addre3 != null)
                    {
                        _context.RemoveRange(addre3);
                    }

                    foreach (var item in contactVM.EmailTable)
                    {
                        item.AddressId = contactVM.addressTable.AddressId;
                        if (item.EmailAddress == null)
                        {
                            contactVM.EmailTable.Remove(item);
                        }
                    }
                    await _context.AddRangeAsync(contactVM.EmailTable);


                    if (addre4 != null)
                    {
                        _context.RemoveRange(addre4);
                    }
                    foreach (var item in contactVM.SocialTable)
                    {
                        item.AddressId = contactVM.addressTable.AddressId;
                        if (item.SocialLink == null || item.SocialType == null)
                        {
                            contactVM.SocialTable.Remove(item);
                        }

                    }
                    await _context.AddRangeAsync(contactVM.SocialTable);

                    TempData["Success"] = "Address Successfully Updated";


                    //addre1.MobileNo1 = contactVM.mobileTable.MobileNo1;
                    //addre1.MobileNo3 = contactVM.mobileTable.MobileNo3;
                    //addre1.MobileNo4 = contactVM.mobileTable.MobileNo4;
                    //addre2.LandlineNo = contactVM.landlineTable.LandlineNo;
                    //addre3.EmailAddress = contactVM.emailTable.EmailAddress;
                    //addre4.SocialType = contactVM.socialTable.SocialType;
                    //addre4.SocialLink = contactVM.socialTable.SocialLink;
                    //addre5.LocationSrc = contactVM.locationTable.LocationSrc;
                    addre5.Website = contactVM.locationTable.Website;
                    addre5.Latitude = contactVM.locationTable.Latitude;
                    addre5.Longitude = contactVM.locationTable.Longitude;

                    _context.Entry(addre);
                    //_context.Entry(addre2);
                    //_context.Entry(addre3);
                    //_context.Entry(addre4);
                    _context.Entry(addre5);
                    await _context.SaveChangesAsync();
                    return LocalRedirect("/Customer/AddressTables/Index?businessid=" + contactVM.addressTable.BusinessId + "&category=" + category);

                }

                else
                {
                    if (ModelState.IsValid)
                    {
                        var claimsIdentity = (ClaimsIdentity)User.Identity;
                        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                        contactVM.addressTable.UserId = claim.Value;
                        //var addre = await _context.AddressTables.FindAsync(contactVM.addressTable.AddressId);
                        List<SelectListItem> addresstype = new List<SelectListItem>();
                        addresstype.Add(new SelectListItem() { Text = "Home", Value = "Home" });
                        addresstype.Add(new SelectListItem() { Text = "Business", Value = "Business" });
                        ViewBag.Addresstype = new SelectList(addresstype, "Value", "Text");

                        _context.Add(contactVM.addressTable);
                        _context.SaveChanges();
                        //contactVM.mobileTable.AddressId = contactVM.addressTable.AddressId;
                        //contactVM.landlineTable.AddressId = contactVM.addressTable.AddressId;
                        //contactVM.emailTable.AddressId = contactVM.addressTable.AddressId;
                        //contactVM.socialTable.AddressId = contactVM.addressTable.AddressId;
                        contactVM.locationTable.AddressId = contactVM.addressTable.AddressId;


                        foreach (var item in contactVM.MobileTable)
                        {
                            item.AddressId = contactVM.addressTable.AddressId;
                            if (item.MobileNo == null)
                            {
                                contactVM.MobileTable.Remove(item);
                            }
                        }
                        await _context.AddRangeAsync(contactVM.MobileTable);
                        //  _context.SaveChanges();
                        foreach (var item in contactVM.LandlineTable)
                        {
                            item.AddressId = contactVM.addressTable.AddressId;
                            if (item.LandlineNo == null)
                            {
                                contactVM.LandlineTable.Remove(item);
                            }
                        }
                        await _context.AddRangeAsync(contactVM.LandlineTable);

                        // _context.SaveChanges();

                        foreach (var item in contactVM.EmailTable)
                        {
                            item.AddressId = contactVM.addressTable.AddressId;
                            if (item.EmailAddress == null)
                            {
                                contactVM.EmailTable.Remove(item);
                            }
                        }
                        await _context.AddRangeAsync(contactVM.EmailTable);

                        //  _context.SaveChanges();
                        foreach (var item in contactVM.SocialTable)
                        {
                            item.AddressId = contactVM.addressTable.AddressId;
                            if (item.SocialLink == null || item.SocialType == null)
                            {
                                contactVM.SocialTable.Remove(item);
                            }

                        }
                        await _context.AddRangeAsync(contactVM.SocialTable);
                        // _context.SaveChanges();
                        _context.Add(contactVM.locationTable);
                        _context.SaveChanges();

                        //_context.AddRange(contactVM.MobileTable);
                        //_context.Add(contactVM.mobileTable);
                        //_context.Add(contactVM.landlineTable);
                        //_context.Add(contactVM.emailTable);
                        //_context.Add(contactVM.socialTable);

                    }

                    TempData["Success"] = "Address Successfully Created";
                    return LocalRedirect("/Customer/AddressTables/Index?businessid=" + contactVM.addressTable.BusinessId + "&category=" + category);

                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }




        // GET: AddressTables/Edit/5
        public IActionResult Retrieve(int? businessid)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);


            //var claimsIdentity = (ClaimsIdentity)User.Identity;
            //var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //ContactVM contactVM = new ContactVM();
            ////contactVM.addressTable.UserId = claim.Value;
            //UserId = claim.Value;



            List<SelectListItem> addresstype = new List<SelectListItem>();
            addresstype.Add(new SelectListItem() { Text = "Home", Value = "Home" });
            addresstype.Add(new SelectListItem() { Text = "Business", Value = "Business" });
            ViewBag.Addresstype = new SelectList(addresstype, "Value", "Text");
            Address addressTable = new Address();
            addressTable.BusinessId = businessid;
            //IEnumerable<MobileTable> mobileTables = Enumerable.Empty<MobileTable>();
            //MobileTable mobileTable = new MobileTable();
            //IEnumerable<LandlineTable> landlineTables = Enumerable.Empty<LandlineTable>();
            //LandlineTable landlineTable = new LandlineTable();
            //IEnumerable<EmailTable> emailTables = Enumerable.Empty<EmailTable>();
            //EmailTable emailTable = new EmailTable();
            //IEnumerable<SocialTable> socialTables = Enumerable.Empty<SocialTable>();
            //SocialTable socialTable = new SocialTable();
            //mobileTables.

            //var addres = await _context.AddressTables.ToListAsync();
            //var addres = (from a in _context.AddressTables where a.UserId == claim.Value select a).ToList();
            var addres = (from a in _context.AddressTables where a.UserId == claim.Value && a.BusinessId == businessid select a).ToList();

            addres.Add(addressTable);
            ContactVM contactVM = new ContactVM();
            contactVM.AddressTable = addres;
            contactVM.addressTable = addressTable;
            contactVM.MobileTable = Enumerable.Empty<Mobile>().ToList();
            contactVM.LandlineTable = Enumerable.Empty<Landline>().ToList();
            contactVM.EmailTable = Enumerable.Empty<Email>().ToList();
            contactVM.SocialTable = Enumerable.Empty<Social>().ToList();
            return View(nameof(Index), contactVM);
        }


        // POST: AddressTables/Edit/5


        //public IActionResult MobileRetrieve(ContactVM contactVM)
        //{
        //    MobileTable mobileTable = new MobileTable();


        //    contactVM.MobileTable.Append(mobileTable);

        //    return View(nameof(Index), contactVM);
        //}


        [HttpGet]
        public async Task<IActionResult> Edit(int AddressId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            try
            {
                //ViewBag.Addresstype = new SelectList(new List<string>() { 0,1 }, 0,"Home", "Office" );
                List<SelectListItem> addresstype = new List<SelectListItem>();
                addresstype.Add(new SelectListItem() { Text = "Home", Value = "Home" });
                addresstype.Add(new SelectListItem() { Text = "Business", Value = "Business" });
                ViewBag.Addresstype = new SelectList(addresstype, "Value", "Text");

                //if (AddressId == null)
                //{
                //    //return NotFound();

                //}
                var addre = await _context.AddressTables.FindAsync(AddressId);
                var addre1 = (from a in _context.MobileTables where a.AddressId == AddressId orderby a.MobileId select a);
                var addre2 = (from a in _context.LandlineTables where a.AddressId == AddressId orderby a.LandlineId select a);
                var addre3 = (from a in _context.EmailTables where a.AddressId == AddressId orderby a.EmailAddressId select a);
                var addre4 = (from a in _context.SocialTables where a.AddressId == AddressId orderby a.SocialId select a);
                var addre5 = await _context.LocationTables.FirstOrDefaultAsync(s => s.AddressId == AddressId);
                if (addre == null)
                {
                    ModelState.AddModelError("", "Something went Wrong");
                    return RedirectToAction(nameof(Index));
                }

                ContactVM contactVM = new ContactVM();


                if (addre.BusinessId != null)
                {
                    contactVM.AddressTable = (from a in _context.AddressTables where a.UserId == claim.Value && a.BusinessId == addre.BusinessId select a).ToList();
                }
                else
                {
                    contactVM.AddressTable = (from a in _context.AddressTables where a.UserId == claim.Value && addre.BusinessId == null select a).ToList();
                }


                //if (addre.BusinessId != null)
                //{
                //    contactVM.AddressTable = (from a in _context.AddressTables where a.UserId == claim.Value && a.BusinessId == addre.BusinessId select a).ToList();
                //}
                //else
                //{
                //    contactVM.AddressTable = (from a in _context.AddressTables where a.UserId == claim.Value && a.BusinessId == null select a).ToList();
                //}

                //contactVM.AddressTable = (from a in _context.AddressTables where a.UserId == claim.Value select a).ToList();
                //if (businessid != null)
                //{
                //    contactVM.AddressTable = contactVM.AddressTable.Where(s => s.BusinessId == businessid).ToList();
                //}
                //else
                //{
                //    contactVM.AddressTable = contactVM.AddressTable.Where(s => s.BusinessId == null).ToList();
                //}


                //contactVM.MobileTable = _context.MobileTables.OrderBy(s => s.AddressId == AddressId).ToList();
                //contactVM.LandlineTable = await _context.LandlineTables.ToListAsync();
                //contactVM.EmailTable = await _context.EmailTables.ToListAsync();
                //contactVM.SocialTable = await _context.SocialTables.ToListAsync();
                //if (addre1.Count() == 0)
                //{
                //    IEnumerable<MobileTable> mobileTables = Enumerable.Empty<MobileTable>();
                //    MobileTable mobileTable = new MobileTable();
                //    contactVM.MobileTable = mobileTables.Append(mobileTable).ToList();
                //}
                //if (addre2.Count() == 0)
                //{
                //    IEnumerable<LandlineTable> landlineTables = Enumerable.Empty<LandlineTable>();
                //    LandlineTable landlineTable = new LandlineTable();
                //    contactVM.LandlineTable = landlineTables.Append(landlineTable).ToList();
                //}
                //if (addre3.Count() == 0)
                //{
                //    IEnumerable<EmailTable> Emailtables = Enumerable.Empty<EmailTable>();
                //    EmailTable emailTable = new EmailTable();
                //    contactVM.EmailTable = Emailtables.Append(emailTable).ToList();
                //}
                //if (addre4.Count() == 0)
                //{
                //    IEnumerable<SocialTable> SocialTables = Enumerable.Empty<SocialTable>();
                //    SocialTable socialTable = new SocialTable();
                //    contactVM.SocialTable = SocialTables.Append(socialTable).ToList();
                //}
                //await _context.SaveChangesAsync();
                //contactVM.mobileTable.AddressId = contactVM.addressTable.AddressId;
                //contactVM.landlineTable.AddressId = contactVM.addressTable.AddressId;
                //contactVM.emailTable.AddressId = contactVM.addressTable.AddressId;
                //contactVM.socialTable.AddressId = contactVM.addressTable.AddressId;
                //contactVM.locationTable.AddressId = contactVM.addressTable.AddressId;

                //var landline = await _context.LandlineTables.ToListAsync();
                //var email = await _context.EmailTables.ToListAsync();
                //var social = await _context.SocialTables.ToListAsync();
                //var location = await _context.LocationTables.ToListAsync();

                contactVM.addressTable = addre;
                contactVM.MobileTable = addre1.ToList();
                contactVM.LandlineTable = addre2.ToList();
                contactVM.EmailTable = addre3.ToList();
                contactVM.SocialTable = addre4.ToList();
                contactVM.locationTable = addre5;

                return View(nameof(Index), contactVM);

            }
            catch (Exception ex)
            {

                throw;
            }

        }




        // POST: AddressTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddressId,UserId,BusinessId,RecId,HouseNo,AddressField,AreaStreet,CityTown,StateProvinceRegion,Country,Pincode,Landmark,AddressType,IsPrimary")] Address addressTable)
        {
            if (id != addressTable.AddressId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addressTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressTableExists(addressTable.AddressId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(addressTable);
        }

        // GET: AddressTables/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var addressTable = await _context.AddressTables
        //        .FirstOrDefaultAsync(m => m.AddressId == id);
        //    if (addressTable == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(addressTable);
        //}

        // POST: AddressTables/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int AddressId)
        {
            //var addressTable = await _context.AddressTables.FindAsync(id);
            //_context.AddressTables.Remove(addressTable);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            try
            {


                if (AddressId != null)
                {
                    var addressTable = await _context.AddressTables.FindAsync(AddressId);
                    int? businessid = null;
                    //await _context.SaveChangesAsync();
                    //contactVM.mobileTable.AddressId = contactVM.addressTable.AddressId;
                    //contactVM.landlineTable.AddressId = contactVM.addressTable.AddressId;
                    //contactVM.emailTable.AddressId = contactVM.addressTable.AddressId;
                    //contactVM.socialTable.AddressId = contactVM.addressTable.AddressId;
                    //contactVM.locationTable.AddressId = contactVM.addressTable.AddressId;
                    var addre1 = (from a in _context.MobileTables where a.AddressId == AddressId select a);
                    //var mobileTable =  _context.MobileTables.FirstOrDefault(s => s.AddressId == AddressId);
                    var landlinetable = (from a in _context.LandlineTables where a.AddressId == AddressId select a);
                    var emailtable = (from a in _context.EmailTables where a.AddressId == AddressId select a);
                    var socialtable = (from a in _context.SocialTables where a.AddressId == AddressId select a);
                    var locationtable = await _context.LocationTables.FirstOrDefaultAsync(s => s.AddressId == AddressId);
                    if (addressTable != null)
                    {
                        businessid = addressTable.BusinessId;
                        _context.AddressTables.Remove(addressTable);

                    }
                    if (addre1 != null)
                    {
                        _context.MobileTables.RemoveRange(addre1);
                    }
                    if (landlinetable != null)
                    {
                        _context.LandlineTables.RemoveRange(landlinetable);

                    }

                    if (emailtable != null)
                    {
                        _context.EmailTables.RemoveRange(emailtable);
                    }

                    if (socialtable != null)
                    {
                        _context.SocialTables.RemoveRange(socialtable);
                    }

                    if (locationtable != null)
                    {
                        _context.LocationTables.Remove(locationtable);

                    }




                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Address Successfully Deleted";
                    return LocalRedirect("/Customer/AddressTables/Index?businessid=" + businessid);

                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private bool AddressTableExists(int id)
        {
            return _context.AddressTables.Any(e => e.AddressId == id);
        }
    }
}
