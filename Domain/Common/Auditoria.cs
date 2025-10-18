namespace Domain.Common;

public sealed class Auditoria
{
    private Auditoria(string created_by, DateTime created_at, string updated_by, DateTime updated_at, string deleted_by, DateTime deleted_at)
    {
        this.created_by = created_by;
        this.created_at = created_at;
        this.updated_by = updated_by;
        this.updated_at = updated_at;
        this.deleted_by = deleted_by;
        this.deleted_at = deleted_at;


    }


    public string created_by { get; private set; } = string.Empty;
    public DateTime created_at { get; private set; }
    public string updated_by { get; private set; } = string.Empty;
    public DateTime updated_at { get; private set; }
    public string deleted_by { get; private set; } = string.Empty;
    public DateTime deleted_at { get; private set; }
}
