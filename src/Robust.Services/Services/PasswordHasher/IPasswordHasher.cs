﻿namespace JogandoBack.API.Data.Services.PasswordHasher
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool Verify(string password, string passwordHash);
    }
}