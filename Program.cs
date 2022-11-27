using to_do_api.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); //=> adicionando suporte a controller externas;
builder.Services.AddDbContext<AppDbContext>(); //=> adicionando AppDbContext como serviço;

var app = builder.Build();
app.MapControllers(); //=> mapeando controller do projeto (tudo que herde de Controller e Controller.Base)


app.Run();
