namespace ConnectSea.Api.Models {
    public class Navio { 
        public int Id {get;set;}
        public string Nome {get;set;} = null!;
        public string NumeroIMO {get;set;} = null!; // Tipo NS do navio
        public string? Bandeira {get;set;} 
        public int Tonelagem {get;set;} // Da hora, existe uma métrica pra quanto um navio pode carregar em toneladas.
    }
    public class Berco 
    { 
        public int Id {get;set;} 
        public string Nome {get;set;} = null!; 
        public decimal DraftMaximo {get;set;} // Profundidade da agua que um navio pode estar dentro da agua pra navegar em segurança
        public decimal LoaMaximo {get;set;} // LOA - Length OverAll. comprimento máximo do navio pra conseguir atracar nesse berço. TODO: validação de berço na atracação pra impedir navios incompativeis, evitando acidentes 
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
        public List<Carga> Cargas {get;set;} = new(); // Note to self: Lista de itens chegando/partindo. Pensar nisso como itens de transação
    }
    public class Carga 
    { 
        public int Id {get;set;} 
        public int AgendaId {get;set;} 
        public Agenda? Agenda {get;set;} 
        public string Descricao {get;set;} = null!;
        public double PesoEmKg {get;set;} // TODO: Validação pra conseguir puxar a tonelagem do navio e impedir saída se exceder
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
