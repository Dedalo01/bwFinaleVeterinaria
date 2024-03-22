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

                    var gaetano = new Owner()
                    {
                        Id = 4,
                        Name = "Gaetano",
                        Surname = "Montaldo",
                        FiscalCode = "FDPGFLC0GQIJK7VN",
                    };

                    var vecchietto = new Owner()
                    {
                        Id = 5,
                        Name = "Vecchietto",
                        Surname = "Old",
                        FiscalCode = "RFLY7N8XLCGWZYMX",
                    };

                    db.Owners.Add(bilbo);
                    db.Owners.Add(marco);
                    db.Owners.Add(giuseppe);
                    db.Owners.Add(gaetano);
                    db.Owners.Add(vecchietto);

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

                    var agostino = new Pet()
                    {
                        Id = 6,
                        Name = "Agostino",
                        Type = "Rinoceronte",
                        RegistrationDate = new DateTime(2023, 05, 04, 15, 13, 11),
                        CoatColor = "Azzurro Napoli",
                        BirthDate = new DateTime(2001, 09, 11),
                        Microchip = "OT9ZEXMRTVJUXWC"
                    };

                    var cuoricino = new Pet()
                    {
                        Id = 7,
                        Name = "Cuoricino",
                        Type = "Capibara",
                        RegistrationDate = new DateTime(2020, 11, 21, 15, 13, 11),
                        CoatColor = "Grigio",
                        BirthDate = new DateTime(2018, 03, 11),
                        Microchip = "J0G419TVS2SFTRT"
                    };

                    var wailord = new Pet()
                    {
                        Id = 8,
                        Name = "Wailord",
                        Type = "Balena",
                        RegistrationDate = new DateTime(2021, 11, 21, 15, 13, 11),
                        CoatColor = "Grigio",
                        BirthDate = new DateTime(1990, 03, 11),
                        Microchip = "1O9FUZP8UVBQYL5"
                    };


                    db.Pets.Add(bobbyDog);
                    db.Pets.Add(pongo);
                    db.Pets.Add(samira);
                    db.Pets.Add(samiro);
                    db.Pets.Add(tortuga);
                    db.Pets.Add(agostino);
                    db.Pets.Add(cuoricino);
                    db.Pets.Add(wailord);

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

                    var admission3 = new RescueAdmission()
                    {
                        Id = 3,
                        AdmissionDate = new DateTime(2020, 12, 08, 11, 14, 07),
                        PetImageUrl = "https://www.repstatic.it/content/nazionale/img/2020/06/16/201320950-49cc995c-45bf-4fed-8d74-6f76a0b4d421.jpg",
                        PetId = 6,
                        Price = price
                    };

                    var admission4 = new RescueAdmission()
                    {
                        Id = 4,
                        AdmissionDate = new DateTime(2021, 08, 08, 11, 14, 07),
                        PetImageUrl = "https://www.rainforest-alliance.org/wp-content/uploads/2021/06/capybara-square-1.jpg.optimal.jpg",
                        PetId = 7,
                        Price = price
                    };

                    var admission5 = new RescueAdmission()
                    {
                        Id = 5,
                        AdmissionDate = new DateTime(2020, 02, 08, 11, 14, 07),
                        PetImageUrl = "https://www.focusjunior.it/content/uploads/2019/05/balena.jpeg",
                        PetId = 8,
                        Price = price
                    };

                    db.RescueAdmissions.Add(admission1);
                    db.RescueAdmissions.Add(admission2);
                    db.RescueAdmissions.Add(admission3);
                    db.RescueAdmissions.Add(admission4);
                    db.RescueAdmissions.Add(admission5);

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

                    var exam4 = new Examination()
                    {
                        Id = 4,
                        ExaminationDate = new DateTime(2021, 09, 03),
                        ObjectiveExamimation = "TROPPO CARINO",
                        TreatmentDescription = "Consiglio vivamente coccole e bacini",
                        PetId = 7
                    };

                    var exam5 = new Examination()
                    {
                        Id = 5,
                        ExaminationDate = new DateTime(2023, 01, 23),
                        ObjectiveExamimation = "Respirazione cattiva",
                        TreatmentDescription = "Prendere tanto ossigeno ed aerosol per polmoni forti",
                        PetId = 8
                    };

                    var exam6 = new Examination()
                    {
                        Id = 6,
                        ExaminationDate = new DateTime(2015, 05, 13),
                        ObjectiveExamimation = "Boh non lo so",
                        TreatmentDescription = "Consiglio di fare qualcosa per evitare morte imminente ma non so cosa",
                        PetId = 4
                    };


                    db.Examinations.Add(exam1);
                    db.Examinations.Add(exam2);
                    db.Examinations.Add(exam3);
                    db.Examinations.Add(exam4);
                    db.Examinations.Add(exam5);
                    db.Examinations.Add(exam6);

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
                        Address = "Via del Golfo 11, Londra (LO)"
                    };

                    var mimmoModem = new Company()
                    {
                        Id = 2,
                        Name = "Mimmo Modem SRL",
                        Email = "mimmomodem@mail.com",
                        Address = "Via dei Meme 69, Bergam de Ota (BG)"
                    };

                    var chiesi = new Company()
                    {
                        Id = 3,
                        Name = "Chiesi",
                        Email = "chiesi@mail.com",
                        Address = "via del golfino 13, Parma (PR)"
                    };

                    var abelSRL = new Company()
                    {
                        Id = 4,
                        Name = "Abel Sassu SRL",
                        Email = "calabria@mail.com",
                        Address = "via della nduja 104, Reggio Calabria (RC)"
                    };

                    var giuseppeSRL = new Company()
                    {
                        Id = 5,
                        Name = "Giuseppe Conza SRL",
                        Email = "napoli@mail.com",
                        Address = "via della pizza 104, Napoli (NA)"
                    };

                    db.Companies.Add(pfizer);
                    db.Companies.Add(mimmoModem);
                    db.Companies.Add(chiesi);
                    db.Companies.Add(abelSRL);
                    db.Companies.Add(giuseppeSRL);

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

                    var ossigeno = new Product()
                    {
                        Id = 5,
                        Name = "Ossigeno",
                        Type = "Farmaco",
                        PossibleUses = "Per respirare bene",
                        CompanyId = 5,
                    };

                    var coccole = new Product()
                    {
                        Id = 6,
                        Name = "Coccole",
                        Type = "Farmaco",
                        PossibleUses = "PER DARE TANTO AMORE <3",
                        CompanyId = 5,
                    };

                    var nduja = new Product()
                    {
                        Id = 7,
                        Name = "Nduja",
                        Type = "Alimentare",
                        PossibleUses = "Per pizzicare intestino",
                        CompanyId = 4,
                    };

                    var pasta = new Product()
                    {
                        Id = 8,
                        Name = "Pasta e pummarola",
                        Type = "Alimentare",
                        PossibleUses = "Per rendere l'animale un vero italiano",
                        CompanyId = 4,
                    };

                    var bomba = new Product()
                    {
                        Id = 9,
                        Name = "Bomba Atomica",
                        Type = "Alimentare",
                        PossibleUses = "Per combattere forti virus",
                        CompanyId = 4,
                    };

                    db.Products.Add(viagra);
                    db.Products.Add(paracetamolo);
                    db.Products.Add(crocchetteBronte);
                    db.Products.Add(crocchetteGelato);
                    db.Products.Add(ossigeno);
                    db.Products.Add(coccole);
                    db.Products.Add(nduja);
                    db.Products.Add(pasta);
                    db.Products.Add(bomba);

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

                    var sale3 = new Sale()
                    {
                        Id = 3,
                        ExaminationId = 4,
                        ProductId = 6,
                        OwnerId = 3,
                        SaleDate = new DateTime(2024, 04, 18),
                    };

                    var sale4 = new Sale()
                    {
                        Id = 4,
                        ExaminationId = 5,
                        ProductId = 5,
                        OwnerId = 4,
                        SaleDate = new DateTime(2024, 04, 22),
                    };

                    var sale5 = new Sale()
                    {
                        Id = 5,
                        ExaminationId = 6,
                        ProductId = 8,
                        OwnerId = 5,
                        SaleDate = new DateTime(2024, 02, 08),
                    };

                    var sale6 = new Sale()
                    {
                        Id = 6,
                        ExaminationId = 6,
                        ProductId = 9,
                        OwnerId = 5,
                        SaleDate = new DateTime(2024, 12, 02),
                    };

                    var sale7 = new Sale()
                    {
                        Id = 7,
                        ExaminationId = 6,
                        ProductId = 7,
                        OwnerId = 5,
                        SaleDate = new DateTime(2024, 07, 17),
                    };


                    db.Sales.Add(sale1);
                    db.Sales.Add(sale2);
                    db.Sales.Add(sale3);
                    db.Sales.Add(sale4);
                    db.Sales.Add(sale5);
                    db.Sales.Add(sale6);
                    db.Sales.Add(sale7);

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

                    var cabinet5 = new Cabinet()
                    {
                        Id = 5,
                        NumericCode = "A",
                        DrawerId = 3,
                        ProductId = 5,
                    };

                    var cabinet6 = new Cabinet()
                    {
                        Id = 6,
                        NumericCode = "B",
                        DrawerId = 3,
                        ProductId = 6,
                    };

                    var cabinet7 = new Cabinet()
                    {
                        Id = 7,
                        NumericCode = "A",
                        DrawerId = 1,
                        ProductId = 7,
                    };

                    var cabinet8 = new Cabinet()
                    {
                        Id = 8,
                        NumericCode = "B",
                        DrawerId = 1,
                        ProductId = 8,
                    };

                    var cabinet9 = new Cabinet()
                    {
                        Id = 9,
                        NumericCode = "B",
                        DrawerId = 2,
                        ProductId = 9,
                    };

                    db.Cabinets.Add(cabinet1);
                    db.Cabinets.Add(cabinet2);
                    db.Cabinets.Add(cabinet3);
                    db.Cabinets.Add(cabinet4);
                    db.Cabinets.Add(cabinet5);
                    db.Cabinets.Add(cabinet6);
                    db.Cabinets.Add(cabinet7);
                    db.Cabinets.Add(cabinet8);
                    db.Cabinets.Add(cabinet9);

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
                    //DOTTORI
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
                        Username = "Peppino",
                        Password = "123",
                        RoleId = 1
                    };

                    //FARMACISTI
                    var employee3 = new Employee()
                    {
                        Id = 3,
                        Username = "Rezzonico",
                        Password = "bruttoX3",
                        RoleId = 2
                    };

                    var employee4 = new Employee()
                    {
                        Id = 4,
                        Username = "Patricia",
                        Password = "123",
                        RoleId = 2
                    };

                    db.Employees.Add(employee1);
                    db.Employees.Add(employee2);
                    db.Employees.Add(employee3);
                    db.Employees.Add(employee4);

                    db.SaveChanges();
                }
            }
        }


    }
}
