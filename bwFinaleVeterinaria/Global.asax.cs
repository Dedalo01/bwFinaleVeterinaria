using bwFinaleVeterinaria.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace bwFinaleVeterinaria
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitializeDb();
        }

        // classe per popolare db
        private void InitializeDb()
        {
            using (var db = new VeterinariaDbContext())
            {
                // OWNERS TABLE
                if (!db.Owners.Any())
                {
                    var bilbo = new Owner()
                    {
                        Id = 1,
                        Name = "Bilbo",
                        Surname = "Beggins",
                        FiscalCode = "POIUYTREWQASDFGH",
                    };

                    var marco = new Owner()
                    {
                        Id = 2,
                        Name = "Marco",
                        Surname = "D'Imprima",
                        FiscalCode = "MNBVCXZASDFGHJKL",
                    };

                    var giuseppe = new Owner()
                    {
                        Id = 3,
                        Name = "Giuseppe",
                        Surname = "Conza",
                        FiscalCode = "LKJHGFDSAZXCVBNM",
                    };

                    db.Owners.Add(bilbo);
                    db.Owners.Add(marco);
                    db.Owners.Add(giuseppe);

                    db.SaveChanges();
                }

                // PETS TABLE
                if (!db.Pets.Any())
                {
                    var bobbyDog = new Pet()
                    {
                        Id = 1,
                        Name = "Bobby",
                        Type = "Cane",
                        RegistrationDate = new DateTime(2024, 03, 18),
                        CoatColor = "Rosso",
                        BirthDate = new DateTime(2020, 03, 18, 14, 18, 00),
                        Microchip = "POIUYTREWQASDFG",
                        OwnerId = 1
                    };

                    var pongo = new Pet()
                    {
                        Id = 2,
                        Name = "Pongo",
                        Type = "Cane",
                        RegistrationDate = new DateTime(2024, 02, 11, 15, 13, 11),
                        CoatColor = "Nero",
                        BirthDate = new DateTime(1997, 01, 22),
                        Microchip = "MNBVCXZASDFGHJK",
                        OwnerId = 2
                    };

                    var samira = new Pet()
                    {
                        Id = 3,
                        Name = "Samira",
                        Type = "Gatto",
                        RegistrationDate = new DateTime(2024, 02, 11, 15, 13, 11),
                        CoatColor = "Nero e Bianco",
                        BirthDate = new DateTime(1997, 01, 22),
                        Microchip = "LKJHGFDSAZXCVBN",
                        OwnerId = 3
                    };

                    // senza padroni
                    var samiro = new Pet()
                    {
                        Id = 4,
                        Name = "Samiro",
                        Type = "Gatto",
                        RegistrationDate = new DateTime(2019, 02, 07, 18, 12, 11),
                        CoatColor = "Nero e Giallo",
                    };

                    var tortuga = new Pet()
                    {
                        Id = 5,
                        Name = "Tortuga",
                        Type = "Tartaruga",
                        RegistrationDate = new DateTime(2015, 01, 19, 11, 11, 11),
                        CoatColor = "Verde",
                    };

                    db.Pets.Add(bobbyDog);
                    db.Pets.Add(pongo);
                    db.Pets.Add(samira);
                    db.Pets.Add(samiro);
                    db.Pets.Add(tortuga);

                    db.SaveChanges();
                }

                // RESCUE ADMISSIONS TABLE
                if (!db.RescueAdmissions.Any())
                {
                    var price = 10.99M;

                    var admission1 = new RescueAdmission()
                    {
                        Id = 1,
                        AdmissionDate = new DateTime(2019, 02, 08, 11, 14, 07),
                        PetImageUrl = "https://www.petme.it/wp-content/uploads/2023/03/334607911_132923772799008_8383502530396146479_n.jpg",
                        PetId = 4,
                        Price = price
                    };

                    var admission2 = new RescueAdmission()
                    {
                        Id = 2,
                        AdmissionDate = new DateTime(2019, 02, 08, 11, 14, 07),
                        PetImageUrl = "https://www.greenme.it/wp-content/uploads/2014/03/chelonia-mydas1.jpg",
                        PetId = 5,
                        Price = price
                    };

                    db.RescueAdmissions.Add(admission1);
                    db.RescueAdmissions.Add(admission2);

                    db.SaveChanges();
                }

                // EXAMINATIONS TABLE
                if (!db.Examinations.Any())
                {
                    var exam1 = new Examination()
                    {
                        Id = 1,
                        ExaminationDate = new DateTime(2023, 12, 15),
                        ObjectiveExamimation = "L'Animale fa miao...",
                        TreatmentDescription = "consiglio Crocchette Al Pistacchio di Bronte perchè hanno benefici divini",
                        PetId = 5
                    };

                    var exam2 = new Examination()
                    {
                        Id = 2,
                        ExaminationDate = new DateTime(2024, 01, 15),
                        ObjectiveExamimation = "L'Animale si è rotto il polso...",
                        TreatmentDescription = "Bendaggi per il bolso",
                        PetId = 1
                    };

                    var exam3 = new Examination()
                    {
                        Id = 3,
                        ExaminationDate = new DateTime(2010, 05, 13),
                        ObjectiveExamimation = "Vescica debole",
                        TreatmentDescription = "Consiglio Viagra per forte sensualità",
                        PetId = 2
                    };

                    db.Examinations.Add(exam1);
                    db.Examinations.Add(exam2);
                    db.Examinations.Add(exam3);

                    db.SaveChanges();
                }

                // COMPANIES TABLE
                if (!db.Companies.Any())
                {
                    var pfizer = new Company()
                    {
                        Id = 1,
                        Name = "Pfizer",
                        Email = "pfizer@vaccins.com",
                        Address = "Via del Golfo, 11, Londra (LO)"
                    };

                    var mimmoModem = new Company()
                    {
                        Id = 2,
                        Name = "Mimmo Modem SRL",
                        Email = "mimmomodem@mail.com",
                        Address = "Via dei Meme, 69, Bergam de Ota (BG)"
                    };

                    var chiesi = new Company()
                    {
                        Id = 3,
                        Name = "Chiesi",
                        Email = "chiesi@mail.com",
                        Address = "via del golfino, 13, Parma (PR)"
                    };

                    db.Companies.Add(pfizer);
                    db.Companies.Add(mimmoModem);
                    db.Companies.Add(chiesi);

                    db.SaveChanges();
                }

                // PRODUCTS TABLE
                if (!db.Products.Any())
                {
                    // type può essere Farmaco o Alimentare
                    var viagra = new Product()
                    {
                        Id = 1,
                        Name = "Viagra",
                        Type = "Farmaco",
                        PossibleUses = "Vescica debole, Orticaria, Basso testosterone, Alti estrogeni",
                        CompanyId = 1,
                    };

                    var paracetamolo = new Product()
                    {
                        Id = 2,
                        Name = "Paracetamolo",
                        Type = "Farmaco",
                        PossibleUses = "TUTTO",
                        CompanyId = 3,
                    };

                    var crocchetteBronte = new Product()
                    {
                        Id = 3,
                        Name = "Croccantini al Pistacchio di Bronte",
                        Type = "Alimentare",
                        PossibleUses = "Torte, Pasta, Ciotole",
                        CompanyId = 2,
                    };

                    var crocchetteGelato = new Product()
                    {
                        Id = 4,
                        Name = "Crocchette al gusto di Gelato al Cioccolato",
                        Type = "Alimentare",
                        PossibleUses = "Per fame improvvisa",
                        CompanyId = 2,
                    };

                    db.Products.Add(viagra);
                    db.Products.Add(paracetamolo);
                    db.Products.Add(crocchetteBronte);
                    db.Products.Add(crocchetteGelato);

                    db.SaveChanges();
                }

                // SALES TABLE
                if (!db.Sales.Any())
                {
                    var sale1 = new Sale()
                    {
                        Id = 1,
                        ExaminationId = 2,
                        ProductId = 2,
                        OwnerId = 1,
                        SaleDate = new DateTime(2021, 12, 02),
                    };

                    var sale2 = new Sale()
                    {
                        Id = 2,
                        ExaminationId = 3,
                        ProductId = 1,
                        OwnerId = 2,
                        SaleDate = new DateTime(2024, 04, 18),
                    };

                    db.Sales.Add(sale1);
                    db.Sales.Add(sale2);

                    db.SaveChanges();
                }

                // DRAWERS TABLE
                if (!db.Drawers.Any())
                {
                    var drawer1 = new Drawer()
                    {
                        Id = 1,
                        DrawerNumber = 1,
                    };

                    var drawer2 = new Drawer()
                    {
                        Id = 2,
                        DrawerNumber = 2,
                    };

                    var drawer3 = new Drawer()
                    {
                        Id = 3,
                        DrawerNumber = 3,
                    };

                    db.Drawers.Add(drawer1);
                    db.Drawers.Add(drawer2);
                    db.Drawers.Add(drawer3);

                    db.SaveChanges();
                }

                // CABINETS TABLE 
                if (!db.Cabinets.Any())
                {
                    var cabinet1 = new Cabinet()
                    {
                        Id = 1,
                        NumericCode = "A",
                        DrawerId = 1,
                        ProductId = 1,
                    };

                    var cabinet2 = new Cabinet()
                    {
                        Id = 2,
                        NumericCode = "A",
                        DrawerId = 2,
                        ProductId = 2,
                    };

                    var cabinet3 = new Cabinet()
                    {
                        Id = 3,
                        NumericCode = "B",
                        DrawerId = 1,
                        ProductId = 3,
                    };

                    var cabinet4 = new Cabinet()
                    {
                        Id = 4,
                        NumericCode = "B",
                        DrawerId = 3,
                        ProductId = 4,
                    };

                    db.Cabinets.Add(cabinet1);
                    db.Cabinets.Add(cabinet2);
                    db.Cabinets.Add(cabinet3);
                    db.Cabinets.Add(cabinet4);

                    db.SaveChanges();
                }

                // ROLES TABLE
                if (!db.Roles.Any())
                {
                    var doctor = new Role()
                    {
                        Id = 1,
                        RoleName = "Doctor",
                    };

                    var pharmacist = new Role()
                    {
                        Id = 2,
                        RoleName = "Pharmacist",
                    };

                    db.Roles.Add(doctor);
                    db.Roles.Add(pharmacist);

                    db.SaveChanges();
                }

                // EMPLOYEES TABLE
                if (!db.Employees.Any())
                {
                    var employee1 = new Employee()
                    {
                        Id = 1,
                        Username = "Giacomo",
                        Password = "12345",
                        RoleId = 1
                    };

                    var employee2 = new Employee()
                    {
                        Id = 2,
                        Username = "Rezzonico",
                        Password = "bruttoX3",
                        RoleId = 2
                    };

                    var employee3 = new Employee()
                    {
                        Id = 3,
                        Username = "Patricia",
                        Password = "123",
                        RoleId = 2
                    };

                    db.Employees.Add(employee1);
                    db.Employees.Add(employee2);
                    db.Employees.Add(employee3);

                    db.SaveChanges();
                }
            }
        }


    }
}
