﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Core.XPML
{
    /// <summary>
    /// Tipos de Propiedades XPML
    /// </summary>
    public enum XPMLPropertyType
    {
        /// <summary>
        /// String field
        /// </summary>
        String,
        /// <summary>
        /// Char field
        /// </summary>
        Char,
        /// <summary>
        /// Int field
        /// </summary>
        Int,
        /// <summary>
        /// Boolena field
        /// </summary>
        Boolean,
        /// <summary>
        /// List field
        /// </summary>
        List,
        /// <summary>
        /// Enum field
        /// </summary>
        Enum,
        /// <summary>
        /// Object field
        /// </summary>
        Object
    }
}
