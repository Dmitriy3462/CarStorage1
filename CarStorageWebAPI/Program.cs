using CarStorage.BAL.Interfaces;
using CarStorage.BAL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICarService, CarServises>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductServices>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddControllersWithViews(); //тест 
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else//test
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();//test
app.UseRouting();//test
app.UseCors("corsapp");

app.MapControllers();

app.Run();

app.UseDefaultFiles();//test
app.UseStaticFiles();//test



