using Invest.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Invest.WebApi.Commands.ConsolidadoCommands;

namespace Invest.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsolidadoController : ControllerBase
    {

        private readonly ILogger<ConsolidadoController> logger;
        private readonly IConfiguration config;
        private readonly IConsolidadoService consolidadoService;

        public ConsolidadoController(
            ILogger<ConsolidadoController> logger,
            IConsolidadoService consolidadoService,
            IConfiguration config)
        {
            this.logger = logger;
            this.config = config;
            this.consolidadoService = consolidadoService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var resultado = await this.consolidadoService.ObterExtratoConsolidado();

                if (resultado.Investimentos.Count == 0)
                    return NotFound("Nenhum investimento foi encontrado.");

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message + "-" + ex.StackTrace);
                return StatusCode(500, "Ocorreu um erro interno.");
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login(AutenticarUsuarioCommand command)
        {
            if (command.Login == "easynvest" && command.Senha == "1234")
            {
                var claims = new[]
                {
                    new Claim("userId", Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.config["Authentication:SecretKey"]));
                var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    claims: claims,
                    signingCredentials: credential,
                    expires: DateTime.Now.AddMinutes(300),
                    issuer: this.config["Authentication:Issuer"],
                    audience: this.config["Authentication:Audience"]
                );

                var jwtToken = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                };

                return Ok(jwtToken);
            }
            else
                return Unauthorized();
        }
    }
}