namespace BadgeCatalog.Domain.Entities;

public class BadgeClass : Entity
{
    #region Properties
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public string UrlImagem { get; private set; }
    public string UrlCriterios { get; private set; }
    #endregion
    #region Constructors
    public BadgeClass(string nome, string descricao, string urlImagem, string urlCriterios)
    {
        Nome = nome;
        Descricao = descricao;
        UrlImagem = urlImagem;
        UrlCriterios = urlCriterios;
    }
    #endregion
}