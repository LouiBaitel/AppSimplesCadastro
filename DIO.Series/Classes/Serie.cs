namespace DIO.Series.Classes
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Tipo { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set;}
        private int Ano { get; set;}
        private string Diretor { get; set; }
        private bool Excluido {get; set;}

        //Metodos

        public Serie(int id, Genero genero, string tipo, string titulo, string descricao, int ano, string diretor)
        {
            this.Id = id;
            this.Genero = genero;
            this.Tipo = tipo;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Diretor = diretor;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo: " + this.Tipo + Environment.NewLine;
            retorno += "Genero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Inicio: " + this.Ano + Environment.NewLine;
            retorno += "Diretor: " + this.Diretor + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir(){
            this.Excluido = true;
        }

    
    }
}