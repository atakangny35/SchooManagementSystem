namespace OkulYönetim.Constances
{
    public static class Constance
    {
        public const string DersNotFound = "Ders Id Bilgisi boş geçilemez";
        public const string UserAlreadyHasDers = " Kullanıcı zaten bu Derse Sahip!";
        public const string RoleAdmin = "Admin";
        public const string RoleOgrenci = "Öğrenci";
        public const string RoleOgretmen = "Öğretmen";
        public const string AdministratorOrUser = RoleAdmin + "," + RoleOgretmen;
        //public static string RoleOgretmen = "Öğretmen";
        public static string AddedCompany = "Kayıt Başarılı";
        public static string UserNotFOund = "Kişi bulunamadı!";
        ///public static string UserNotFOund = "Kişi bulunamadı!";
        public static string  PassworMust = "Şifre boş geçilemez!";
        public static string UserRoleNotFOund = "Ünvan Kaydı sistemde Bulunamadı!";
        public static string AccountReconcilationDetailNotFound = "Cari mutabakatı detayları bulunamadı";
        public static string WrongPassword = "Kullanıcı adı veya şifre yanlış";
        public static string SuccessLogin = "Giriş Başarılı";
        public static string UserRegistered = "KUllanıcı Kaydı başarılı";
        public static string UserExists = "İlgili mail adresi için kullanıcı mevcut";
        public static string CompanyExists = "İlgili vergi numarası ve departmanı için Şirket msevcut";
        public static string MailParameterUpdated = "Mail parametreleri Başarıyla düzenlendi";
        public static string MailSended = "Mail başarıyla gönderildi";
        public static string GeneralSuccess = "İşlem başarılı";
        public static string MailConfirmed = "Kullanıcı Maili Onaylandı";
        public static string MailConfirmEmailSend = "Kullanıcı onay Maili gönderildi";
        public static string UserAlreadyConfirmed = "Kullanıcı Zaten onaylanmış!";
        public static string MailJustSended = "Son Mail gönderimi üzerinden en az 5 dakika geçmelidir!";
        public static string UserCompanyNotFound = "Kullanıcının Tanımlı olduğu bir Şİrket bulunamadı!";
        public static string MustBeEmail = "Lütfen Geçerli bir E-mail adresi giriniz!";
        public static string NameMust = "Kullanıcı adı boş geçilemez!";
        public static string RoleMust = "Kişi ünvanı boş geçilemez!";
        public static string MailMust = "Mail adresi boş geçilemez!";
        public static string CompanyNameNotEmpty = "Şirket Adı boş geçilemez!";
        public static string CompanyAdressNotEmpty = "Şirket adresi boş geçilemez!";
        public static string UpdatedCompny = "Şirket GÜncellendi!";
        public static string UpdatedCurrencyAccount = "Kayıt Başarılı";
        public static string EntityDeleted = "Kayıt Başarıyla silindi";
        public static string EntityUpdated = "Kayıt Başarıyla Güncellendi";
        public static List<string> UnauthorizedClaims = new List<string>() { "Admin", "MailParameter", "MailTemplete", "Operationclaim.crud" };
    }
    
}
