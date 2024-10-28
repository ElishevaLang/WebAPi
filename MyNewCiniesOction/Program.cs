using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyNewCiniesOction;
using MyNewCiniesOction.BL;
using MyNewCiniesOction.DAL;
using webapi;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MyNewCiniesOction.Middleware;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDonorDal, DonorDal>();
builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IGiftDal, GiftDal>();
builder.Services.AddScoped<IGiftService, GiftService>();
builder.Services.AddScoped<IUserDal, UserDal>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICartDal, CartDal>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderDal, OrderDal>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderItemsDal, OrderItemsDal>();
builder.Services.AddScoped<IOrderItemsService, OrderItemsService>();
builder.Services.AddScoped<IRaffleDal, RaffleDal>();
builder.Services.AddScoped<IRaffleService, RaffleService>();
builder.Services.AddScoped<IWinningDal, WinningDal>();
builder.Services.AddScoped<IWinningService, WinningService>();


builder.Services.AddDbContext<ChiniesOctionContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("ChiniesOctionContext"));
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

var mapperConfig = new MapperConfiguration(mc => {
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", //give it the name you want
                  builder =>
                  {
                      builder.WithOrigins("http://localhost:4200",
                                           "development web site")
                                          .AllowAnyHeader()
                                          .AllowAnyMethod()
                                          ;
                  });

});
//==========================

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
options.TokenValidationParameters = new TokenValidationParameters
{
ValidateIssuer = true,
ValidateAudience = true,
ValidateLifetime = true,
ValidateIssuerSigningKey = true,
ValidIssuer = builder.Configuration["Jwt:Issuer"],
ValidAudience = builder.Configuration["Jwt:Audience"],
IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
};
});

builder.Services.AddSwaggerGen(c =>
{
c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
    Description = "JWT Authorization header using the Bearer scheme",
    Type = SecuritySchemeType.Http,
    Scheme = "bearer"
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

c.OperationFilter<SecurityRequirementsOperationFilter>();
});
//========================
//=========================================================

var app = builder.Build();

// Configure the HTTP request pipeline.



if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();//\\\\\\\\\\\\
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}///\\\\\\\\\\\\\\\\\\




app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("CorsPolicy");


app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
//=========================

app.UseWhen(context => !context.Request.Path.StartsWithSegments("/api/User/userByEmailPassword") && !context.Request.Path.StartsWithSegments("/api/User"), orderApp =>
{
orderApp.Use(async (context, next) =>
{
    if (context.Request.Headers.ContainsKey("Authorization"))
    {
        var authorizationHeader = context.Request.Headers["Authorization"].ToString();
        if (authorizationHeader.StartsWith("Bearer "))
        {
            context.Request.Headers["Authorization"] = authorizationHeader.Substring("Bearer ".Length);
        }
    }

    await next();
});
orderApp.UseMiddleware<AuthenticationMiddleware>();
});
//=========================

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
//app.MapControllers();
/*app.UseCors("CorsPolicy");*///!!

app.Run();

