using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elf_Tool
{
    // Read Elf header
    class Elf
    {
        public sbyte[] e_ident  // Elf identifier
        { get; set; }
        public UInt16 e_type  // Elf Type
        { get; set; }
        public UInt16 e_machine  // Elf Machine
        { get; set; }
        public UInt32 e_version  // Elf Version
        { get; set; }
        public UInt32 e_entry  // property
        { get; set; }
        public UInt32 e_phoff  // property
        { get; set; }
        public UInt32 e_shoff  // property
        { get; set; }
        public UInt32 e_flags  // property
        { get; set; }
        public UInt16 e_ehsize  // property
        { get; set; }
        public UInt16 e_phentsize  // property
        { get; set; }
        public UInt16 e_phnum  // property
        { get; set; }
        public UInt16 e_shentsize  // property
        { get; set; }
        public UInt16 e_shnum  // property
        { get; set; }
        public UInt16 e_shstrndx  // property
        { get; set; }
    }
}
