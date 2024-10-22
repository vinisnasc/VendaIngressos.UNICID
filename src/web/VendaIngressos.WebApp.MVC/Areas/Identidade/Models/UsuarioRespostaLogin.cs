﻿using VendaIngressos.WebApp.MVC.Models;

namespace VendaIngressos.WebApp.MVC.Areas.Identidade.Models
{
    public class UsuarioRespostaLogin
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioToken UsuarioToken { get; set; }
        public ResponseResult ResponseResult { get; set; }
    }
}