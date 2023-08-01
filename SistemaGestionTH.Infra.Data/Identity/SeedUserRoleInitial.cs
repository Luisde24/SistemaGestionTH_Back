using Microsoft.AspNetCore.Identity;
using SistemaGestionTH.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Infra.Data.Identity
{

    public class SeedUserRoleInitial : ISeedUserRoleInitial
    { 
         private readonly UserManager<ApplicationUser> _userManager;
         private readonly RoleManager<IdentityRole> _roleManager;
        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }

        public void SeedRoles()
        {

            if (!_roleManager.RoleExistsAsync("Empleado").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Empleado";
                role.NormalizedName = "EMPLEADO";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Gerencia").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Gerencia";
                role.NormalizedName = "GERENCIA";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Talento Humano").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Recurso Humano";
                role.NormalizedName = "RECURSO HUMANO";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Nomina").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Nomina";
                role.NormalizedName = "NOMINA";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Lider de Area").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Lider de Area";
                role.NormalizedName = "LIDER DE AREA";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("usuario@empleado.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "usuario@empleado.com";
                user.Email = "usuario@empleado.com";
                user.NormalizedUserName = "USUARIO@EMPLEADO.COM";
                user.NormalizedEmail = "USUARIO@EMPLEADO.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "mLemouw30*").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Empleado").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("usuario@gerencia.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "usuario@gerencia.com";
                user.Email = "usuario@gerencia.com";
                user.NormalizedUserName = "USUARIO@GERENCIA.COM";
                user.NormalizedEmail = "USUARIO@GERENCIA.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "mLemouw30*").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Gerencia").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("usuario@talentoHumano.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "usuario@talentoHumano.com";
                user.Email = "usuario@talentoHumano.com";
                user.NormalizedUserName = "USUARIO@TALENTOHUMANO.COM";
                user.NormalizedEmail = "USUARIO@TALENTOHUMANO.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "mLemouw30*").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Talento Humano").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("usuario@nomina.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "usuario@nomina.com";
                user.Email = "usuario@nomina.com";
                user.NormalizedUserName = "USUARIO@NOMINA.COM";
                user.NormalizedEmail = "USUARIO@NOMINA.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "mLemouw30*").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Nomina").Wait();
                }
            }
            if (_userManager.FindByEmailAsync("usuario@liderArea.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "usuario@liderArea.com";
                user.Email = "usuario@liderArea.com";
                user.NormalizedUserName = "USUARIO@LIDERAREA.COM";
                user.NormalizedEmail = "USUARIO@LIDERAREA.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "mLemouw30*").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Lider de Area").Wait();
                }
            }
        }
    }
}
