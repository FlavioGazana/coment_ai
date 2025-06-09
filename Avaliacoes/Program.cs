using Avaliacoes.Database;
using Avaliacoes.Gemini;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Avaliacoes.DTO;
using Avaliacoes.Models;
using System.Reflection;
using System.Net;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.AspNetCore.SpaServices.Extensions;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;



namespace Avaliacoes
{
    class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder();

            //configuração do swagger
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Coment AI", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            builder.Services.AddDbContext<AvaDbContext>();

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            //configuração do cors para o uso do view(front)
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Secret))
                    };
                });

            builder.Services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "../Frontend/dist";
            });

            var aplicativo = builder.Build();

            aplicativo.UseCors();

            if (aplicativo.Environment.IsDevelopment())
            {
                aplicativo.UseSwagger();
                aplicativo.UseSwaggerUI();
            }


            aplicativo.UseHttpsRedirection();
            aplicativo.MapControllers();
            aplicativo.UseStaticFiles();
            aplicativo.UseAuthentication();
            aplicativo.UseAuthorization();

            aplicativo.UseSpa(spa =>
            {
                spa.Options.SourcePath = "../Frontend/ecommerce-complete";

                if (aplicativo.Environment.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:8080/");
                }
            });

            aplicativo.Run();

        }
        //static async Task Main()
        //{
        //    //await Api.Prompt();
        //    var builder = WebApplication.CreateBuilder();

        //    builder.Services.AddCors(options =>
        //    {
        //        options.AddPolicy("AllowFrontend", policy =>
        //        {
        //            policy.WithOrigins("https://localhost:5111") // Porta do frontend
        //                  .AllowAnyHeader()
        //                  .AllowAnyMethod();
        //        });
        //    });

        //    builder.Services.AddDbContext<AvaDbContext>();
        //    var app = builder.Build();

        //    app.UseCors("AllowFrontend");
        //    app.UseHttpsRedirection();


        //    app.MapPost("/Produto", async (AvaDbContext context, ProdutoDTO produtoDTO) => {
        //        Console.WriteLine(produtoDTO.nome);

        //        throw new NotImplementedException();
        //    });

        //    app.MapPost("/cadastrarProduto", async(HttpRequest request, AvaDbContext context) => {


        //        var form = await request.ReadFormAsync();

        //        string nome = form["nome"];
        //        string descricao = form["descricao"];
        //        double preco = Convert.ToDouble(form["preco"]);

        //        var novoProduto = new Produto(nome, descricao, preco, new List<Opiniao>());
        //        context.Produtos.Add(novoProduto);
        //        await context.SaveChangesAsync();
        //        return Results.Ok("Produto cadastrado com sucesso!");

        //    });

        //    app.MapPost("/cadastrarOpiniao", async(HttpRequest request, AvaDbContext context) => {
        //        var form2 = await request.ReadFormAsync();

        //        DateTime data = Convert.ToDateTime(form2["data"]);
        //        string nomeProduto = form2["nomeProduto"];
        //        string nomeCliente = form2["nomeCliente"];
        //        double nota = Convert.ToDouble(form2["nota"]);
        //        string opiniao = form2["opiniao"];

        //        var produto = await context.Produtos.FirstOrDefaultAsync(p => p.nome == nomeProduto); //aqui estamos verificando se o produto existe só pelo nome
        //        if (produto == null)
        //        {
        //            return Results.BadRequest("Produto não encontrado");
        //        }

        //        var novaOpiniao = new Opiniao(data, produto, nomeCliente, nota, opiniao, new List<string>());
        //        context.Opinioes.Add(novaOpiniao);
        //        await context.SaveChangesAsync();
        //        return Results.Ok("Opinião cadastrada com sucesso!");

        //    });

        //    app.MapGet("/api/gemini/resposta", async () =>
        //    {
        //        var resultado = await Avaliacoes.Gemini.Api.Prompt();
        //        return Results.Ok(resultado);
        //    });

        //    await Api.Prompt();
        //    await app.RunAsync();
        //}

            
    }
}
