using Microsoft.AspNetCore.Identity;

namespace Rifoms.Web.Infrastructure.Identity
{
    public class RussianIdentityErrorDescriber : IdentityErrorDescriber
    {
        #region ERROR DESCIPTIONS
        /// <summary>
        /// $"An unknown failure has occurred
        /// </summary>
        /// <returns></returns>
        public override IdentityError DefaultError() { return new IdentityError { Code = nameof(DefaultError), Description = $"Произошла неизвестная ошибка." }; }

        /// <summary>
        /// "Optimistic concurrency failure, object has been modified"
        /// </summary>
        /// <returns></returns>
        public override IdentityError ConcurrencyFailure() { return new IdentityError { Code = nameof(ConcurrencyFailure), Description = "«Ошибка оптимистического параллелизма, объект был изменен»." }; }

        /// <summary>
        /// "Incorrect password."
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordMismatch() { return new IdentityError { Code = nameof(PasswordMismatch), Description = "Неверный пароль." }; }

        /// <summary>
        /// "Invalid token."
        /// </summary>
        /// <returns></returns>
        public override IdentityError InvalidToken() { return new IdentityError { Code = nameof(InvalidToken), Description = "«Неверный токен»." }; }

        /// <summary>
        ///  "A user with this login already exists."
        /// </summary>
        /// <returns></returns>
        public override IdentityError LoginAlreadyAssociated() { return new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = "Пользователь с таким логином уже существует." }; }

        /// <summary>
        ///  $"User name '{userName}' is invalid, can only contain letters or digits."
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public override IdentityError InvalidUserName(string userName) { return new IdentityError { Code = nameof(InvalidUserName), Description = $"Имя пользователя '{userName}' недействительно, может содержать только буквы или цифры." }; }

        /// <summary>
        ///  $"Email '{email}' is invalid."
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public override IdentityError InvalidEmail(string email) { return new IdentityError { Code = nameof(InvalidEmail), Description = $"Электронная почта '{email}' недействительна." }; }

        /// <summary>
        /// $"User Name '{userName}' is already taken
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public override IdentityError DuplicateUserName(string userName) { return new IdentityError { Code = nameof(DuplicateUserName), Description = $"Имя пользователя '{userName}' уже занято." }; }

        /// <summary>
        /// Email '{email}' is already taken
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public override IdentityError DuplicateEmail(string email) { return new IdentityError { Code = nameof(DuplicateEmail), Description = $"Электронная почта '{email}' уже занята." }; }

        /// <summary>
        ///  $"Role name '{role}' is invalid."
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public override IdentityError InvalidRoleName(string role) { return new IdentityError { Code = nameof(InvalidRoleName), Description = $"Имя роли '{role}' недопустимо." }; }

        /// <summary>
        ///  $"Role name '{role}' is already taken."
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public override IdentityError DuplicateRoleName(string role) { return new IdentityError { Code = nameof(DuplicateRoleName), Description = $"Имя роли '{role}' уже занято." }; }

        /// <summary>
        /// "Пользователь уже установил пароль."
        /// </summary>
        /// <returns></returns>
        public override IdentityError UserAlreadyHasPassword() { return new IdentityError { Code = nameof(UserAlreadyHasPassword), Description ="Пользователь уже установил пароль."}; }

        /// <summary>
        ///  "Lockout is not enabled for this user."
        /// </summary>
        /// <returns></returns>
        public override IdentityError UserLockoutNotEnabled() { return new IdentityError { Code = nameof(UserLockoutNotEnabled), Description ="«Блокировка не включена для этого пользователя»." }; }

        /// <summary>
        ///  $"User already in role '{role}'."
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public override IdentityError UserAlreadyInRole(string role) { return new IdentityError { Code = nameof(UserAlreadyInRole), Description =$"Пользователь уже в роли '{role}'." }; }

        /// <summary>
        ///  $"User is not in role '{role}'."
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public override IdentityError UserNotInRole(string role) { return new IdentityError { Code = nameof(UserNotInRole), Description =$"Пользователь не в роли '{role}'." }; }

        /// <summary>
        ///  $"Passwords must be at least {length} characters."
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public override IdentityError PasswordTooShort(int length) { return new IdentityError { Code = nameof(PasswordTooShort), Description =$"Пароли должны содержать не менее {length} символов." }; }

        /// <summary>
        ///  "Passwords must have at least one non alphanumeric character."
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordRequiresNonAlphanumeric() { return new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description ="«Пароль должен содержать хотя бы один небуквенно-цифровой символ»."}; }

        /// <summary>
        ///  "Passwords must have at least one digit ('0'-'9')."
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordRequiresDigit() { return new IdentityError { Code = nameof(PasswordRequiresDigit), Description ="«Пароли должны содержать хотя бы одну цифру(от 0 до 9)»." }; }

        /// <summary>
        ///  "Passwords must have at least one lowercase ('a'-'z')."
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordRequiresLower() { return new IdentityError { Code = nameof(PasswordRequiresLower), Description ="«Пароли должны иметь хотя бы одну строчную букву(‘a’-’z’)»." }; }

        /// <summary>
        ///  "Passwords must have at least one uppercase ('A'-'Z')."
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordRequiresUpper() { return new IdentityError { Code = nameof(PasswordRequiresUpper), Description ="«Пароли должны иметь по крайней мере одну прописную букву('A' - 'Z')»." }; }
        #endregion
    }
}

