namespace ConnectSea.Api.Models {
    public class Navio { 
        public int Id {get;set;}
        public string Nome {get;set;} = null!;
        public string NumeroIMO {get;set;} = null!; // Tipo NS do navio
        public string? Bandeira {get;set;} 
        public int Tonelagem {get;set;} // Da hora, existe uma m�trica pra quanto um navio pode carregar em toneladas.
    }
    public class Berco 
    { 
        public int Id {get;set;} 
        public string Nome {get;set;} = null!; 
        public decimal DraftMaximo {get;set;} // Profundidade da agua que um navio pode estar dentro da agua pra navegar em seguran�a
        public decimal LoaMaximo {get;set;} // LOA - Length OverAll. comprimento m�ximo do navio pra conseguir atracar nesse ber�o. TODO: valida��o de ber�o na atraca��o pra impedir navios incompativeis, evitando acidentes 
    }
    public class Agenda 
    { 
        public int Id {get;set;} 
        public int NavioId {get;set;} 
        public Navio? Navio {get;set;} 
        public int BercoId {get;set;} 
        public Berco? Berco {get;set;} 
        public DateTime Chegada {get;set;} 
        public DateTime Partida {get;set;} 
        public string Status {get;set;} = "Planejada"; 
        public List<Carga> Cargas {get;set;} = new(); // Note to self: Lista de itens chegando/partindo. Pensar nisso como itens de transa��o
    }
    public class Carga 
    { 
        public int Id {get;set;} 
        public int AgendaId {get;set;} 
        public Agenda? Agenda {get;set;} 
        public string Descricao {get;set;} = null!;
        public double PesoEmKg {get;set;} // TODO: Valida��o pra conseguir puxar a tonelagem do navio e impedir sa�da se exceder
        public string Tipo {get;set;} = null!; 
    }
    public class Usuario 
    { 
        public int Id {get;set;} 
        public string Username {get;set;} = null!; 
        public string PasswordHash {get;set;} = null!; 
        public string Role {get;set;} = "Operator"; 
    }
}
