//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DraftApp.database
{
    using System;
    using System.Collections.Generic;
    
    public partial class storage
    {
        public int id_material { get; set; }
        public int count { get; set; }
        public byte[] is_storage { get; set; }
        public int count_in_pack { get; set; }
    
        public virtual material material { get; set; }
    }
}
