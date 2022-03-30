using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Movies.ItAcademy.Domain;
using Movies.ItAdcademy.ge.Areas.Identity.Data;

namespace Movies.ItAcademy.PersistenceDb
{
    public class ShareCalsss
    {
        private readonly AdcademygeContext _context;
        public ShareCalsss(AdcademygeContext context)
        {
            _context = context;
        }
        public async Task<bool> LoginShared(LoginSharedModel loginModel)
        {
            var userHashedPassword = new PasswordHasher().HashPassword(loginModel.Password);
            var result = _context.Users.Where(x => x.Email == loginModel.Email && x.PasswordHash == userHashedPassword);
            if(result != null)
            {
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> RegisterShared(RegisterSharedModel registerModel)
        {
            var userhashedPassword = hashePassword(registerModel.Password);
            var userhashedConfirmPassword = hashePassword(registerModel.ConfirmPassword);
            //validacia unda gavaketo tu parolebi emtxveva!!! servisebshi
            registerModel.Password = userhashedPassword;
            registerModel.ConfirmPassword = userhashedConfirmPassword;
            await _context.AddAsync(registerModel);
            try
            {
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong !!!");
            }

        }

        public string hashePassword(string password)
        {
            return new PasswordHasher().HashPassword(password);
        }
    }
}
