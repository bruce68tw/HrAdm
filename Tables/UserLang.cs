using System;
using System.Collections.Generic;

namespace HrAdm.Tables;

public partial class UserLang
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string LangName { get; set; } = null!;

    public byte ListenLevel { get; set; }

    public byte SpeakLevel { get; set; }

    public byte ReadLevel { get; set; }

    public byte WriteLevel { get; set; }

    public int Sort { get; set; }
}
