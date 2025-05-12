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
            return new IdentityError { Code = "PasswordRequiresUniqueChars", Description = $"En az {uniqueChars} farkl� karakter i�ermelidir." };
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
            return new IdentityError { Code = "InvalidEmail", Description = $"Belirtilen email {email} adresi ge�ersizdir." };
        }
        public override IdentityError InvalidRoleName(string role)
        {
            return new IdentityError { Code = "InvalidRoleName", Description = $"Belirtilen rol {role} ismi ge�ersizdir." };
        }
        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError { Code = "InvalidUserName", Description = $"Belirtilen email {userName} adresi ge�ersizdir." };
        }
        public override IdentityError PasswordTooShort(int lenght)
        {
            return new IdentityError { Code = "PasswordTooShort", Description = $"Parola �ok k�sa ({lenght})." };
        }
        public override IdentityError UserAlreadyInRole(string role)
        {
            return new IdentityError { Code = "UserAlreadyInRole", Description = $"Kullan�c� zaten bu role {role} sahip." };
        }
        public override IdentityError UserNotInRole(string role)
        {
            return new IdentityError { Code = "UserNotInRole", Description = $"Kullan�c� bu role {role} sahip de�il!" };
        }
        public override IdentityError ConcurrencyFailure()
        {
            return new IdentityError { Code = "ConcurrencyFailture", Description = "Birden �ok kullan�c� ayn� veriyi de�i�tirmeye �al��t�! De�i�iklikler geri al�nacak!" };
        }
        public override IdentityError LoginAlreadyAssociated()
        {
            return new IdentityError { Code = "LoginAlreadyAssociated", Description = "Bu oturum zaten bir hesap ile ili�kili." };
        }
        public override IdentityError PasswordMismatch()
        {
            return new IdentityError { Code = "PasswordMismatch", Description = "Parola bilgisi uyu�muyor." };
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError { Code = "PasswordRequiresDigit", Description = "Parola en az 1 say� i�ermelidir." };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError { Code = "PasswordRequiresNonAlphanumeric", Description = "Parolan�z en az 2 farkl� karaktere sahip olmal�d�r." };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError { Code = "PasswordRequiresUpper", Description = "Parolan�z en az 1 b�y�k harf i�ermelidir." };
        }
        public override IdentityError RecoveryCodeRedemptionFailed()
        {
            return new IdentityError { Code = "RecoveryCodeRedemptionFailed", Description = "Hesap kurtarma kodu ge�ersiz!" };
        }
        public override IdentityError UserAlreadyHasPassword()
        {
            return new IdentityError { Code = "UserAlreadyHasPassword", Description = "Kullan�c�n�n zaten parolas� var." };
        }
        public override IdentityError DefaultError()
        {
            return new IdentityError { Code = "DefaultError", Description = "Bir hata olu�tu." };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError { Code = "PasswordRequiresLower", Description = "Parolan�z en az 1 k���k harf i�ermelidir." };
        }
        public override IdentityError UserLockoutNotEnabled()
        {
            return new IdentityError { Code = "UserLockoutNotEnabled", Description = "Bu hesap �uanda kilitli! L�tfen daha sonra tekrar deneyin." };
        }
    }

}

