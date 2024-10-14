var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (minimalApi.Dominio.DTO.LoginDTO loginDTO) => {
    if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123")
    {
        return Results.Ok("Login efetuado com sucesso");
    }
    else
    {
        return Results.Unauthorized();
    }
});

app.Run();



