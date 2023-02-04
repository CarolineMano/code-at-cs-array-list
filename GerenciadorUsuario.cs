using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercicioArrayLists
{
    public class GerenciadorUsuario
    {
        private ArrayList _usuarios;

        public GerenciadorUsuario()
        {
            _usuarios = new ArrayList
            {
                "Admin",
                "senha",
                0
            };
        }

        public bool CadastrarUsuario(string nome, string senha)
        {
            if (senha.Length < 4 || senha.Length > 8)
                return false;

            _usuarios.Add(nome);
            _usuarios.Add(senha);
            _usuarios.Add(0);

            return true;
        }

        public CodigoValidacaoUsuario ValidarUsuario(string nome, string senha)
        {
            var usuario = _usuarios.IndexOf(nome);

            if (usuario == -1)
                return CodigoValidacaoUsuario.UsuarioInexistente;

            if ((int)_usuarios[usuario + 2] > 2)
                return CodigoValidacaoUsuario.TentativasEstouradas;

            if ((string)_usuarios[usuario + 1] != senha)
            {
                _usuarios[usuario + 2] = (int)_usuarios[usuario + 2] + 1;
                return (int)_usuarios[usuario + 2] > 2 ? CodigoValidacaoUsuario.TentativasEstouradas : CodigoValidacaoUsuario.SenhaInvalida;
            }

            return CodigoValidacaoUsuario.UsuarioValidado;
        }
    }
}