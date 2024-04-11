using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsersApi.Data.DTOs;
using UsersApi.Models;

namespace UsersApi.Services;

public class UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
{
    private readonly IMapper _mapper = mapper;
    private readonly UserManager<User> _userManager = userManager;
    private readonly SignInManager<User> _signInManager = signInManager;
    private readonly TokenService _tokenService = tokenService;

    private readonly ApplicationException registerException = new("Error to register user!");
    private readonly ApplicationException loginException = new("User not authenticated!");
    private readonly ApplicationException userException = new("Error to find user!");

    public async Task Register(CreateUserDto createUserDto)
    {
        User user = _mapper.Map<User>(createUserDto);
        IdentityResult response = await _userManager.CreateAsync(user, createUserDto.Password);

        if (!response.Succeeded)
        {
            throw registerException;
        }
    }

    public async Task<string> Login(LoginUserDto dto)
    {
        SignInResult response = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

        if (!response.Succeeded)
        {
            throw loginException;
        }

        User user = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper()) ?? throw userException;
        string token = _tokenService.GenerateToken(user);
        return token;
    }
}