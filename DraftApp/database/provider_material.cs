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
    
    public partial class provider_material
    {
        public int id { get; set; }
        public int id_material { get; set; }
        public int id_provider { get; set; }
    
        public virtual material material { get; set; }
        public virtual provider provider { get; set; }
    }
}
