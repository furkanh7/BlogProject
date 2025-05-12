using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Describers
{


    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return new IdentityError { Code = "PasswordRequiresUniqueChars", Description = $"En az {uniqueChars} farklý karakter içermelidir." };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError { Code = "DublicateEmail", Description = $"Bu email {email} adresine ait bir hesap zaten var." };
        }
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError { Code = "DuplicateUserName", Description = $"Bu email {userName} adresine ait bir hesap zaten var." };
        }
        public override IdentityError DuplicateRoleName(string role)
        {
            return new IdentityError { Code = "DublicateRoleName", Description = $"Bu rol {role} ismi zaten mevcut." };
        }
        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError { Code = "InvalidEmail", Description = $"Belirtilen email {email} adresi geçersizdir." };
        }
        public override IdentityError InvalidRoleName(string role)
        {
            return new IdentityError { Code = "InvalidRoleName", Description = $"Belirtilen rol {role} ismi geçersizdir." };
        }
        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError { Code = "InvalidUserName", Description = $"Belirtilen email {userName} adresi geçersizdir." };
        }
        public override IdentityError PasswordTooShort(int lenght)
        {
            return new IdentityError { Code = "PasswordTooShort", Description = $"Parola çok kýsa ({lenght})." };
        }
        public override IdentityError UserAlreadyInRole(string role)
        {
            return new IdentityError { Code = "UserAlreadyInRole", Description = $"Kullanýcý zaten bu role {role} sahip." };
        }
        public override IdentityError UserNotInRole(string role)
        {
            return new IdentityError { Code = "UserNotInRole", Description = $"Kullanýcý bu role {role} sahip deðil!" };
        }
        public override IdentityError ConcurrencyFailure()
        {
            return new IdentityError { Code = "ConcurrencyFailture", Description = "Birden çok kullanýcý ayný veriyi deðiþtirmeye çalýþtý! Deðiþiklikler geri alýnacak!" };
        }
        public override IdentityError LoginAlreadyAssociated()
        {
            return new IdentityError { Code = "LoginAlreadyAssociated", Description = "Bu oturum zaten bir hesap ile iliþkili." };
        }
        public override IdentityError PasswordMismatch()
        {
            return new IdentityError { Code = "PasswordMismatch", Description = "Parola bilgisi uyuþmuyor." };
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError { Code = "PasswordRequiresDigit", Description = "Parola en az 1 sayý içermelidir." };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError { Code = "PasswordRequiresNonAlphanumeric", Description = "Parolanýz en az 2 farklý karaktere sahip olmalýdýr." };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError { Code = "PasswordRequiresUpper", Description = "Parolanýz en az 1 büyük harf içermelidir." };
        }
        public override IdentityError RecoveryCodeRedemptionFailed()
        {
            return new IdentityError { Code = "RecoveryCodeRedemptionFailed", Description = "Hesap kurtarma kodu geçersiz!" };
        }
        public override IdentityError UserAlreadyHasPassword()
        {
            return new IdentityError { Code = "UserAlreadyHasPassword", Description = "Kullanýcýnýn zaten parolasý var." };
        }
        public override IdentityError DefaultError()
        {
            return new IdentityError { Code = "DefaultError", Description = "Bir hata oluþtu." };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError { Code = "PasswordRequiresLower", Description = "Parolanýz en az 1 küçük harf içermelidir." };
        }
        public override IdentityError UserLockoutNotEnabled()
        {
            return new IdentityError { Code = "UserLockoutNotEnabled", Description = "Bu hesap þuanda kilitli! Lütfen daha sonra tekrar deneyin." };
        }
    }

}

