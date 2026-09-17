/*
===========================================================================
Copyright (C) 2019-2026 Project Crystal Dev Team

This file is part of Project Crystal Server.

Project Crystal Server is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Project Crystal Server is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with Project Crystal Server. If not, see <https://www.gnu.org/licenses/>.
===========================================================================
*/

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Crystal.FFXILobbyServer.Network.Receive
{
    public unsafe struct RenameCharPkt
    {
        // Pkt Info
        public const int OPCODE = 0x28;
        public const int SIZE = 0x28;

        // Pkt Data
        public readonly uint FFXIId;
        public readonly uint FFXIIdWorld;
        public fixed byte NewName_[0x10];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10)]
        public readonly byte[] Password;

        public string NewName
        {
            get
            {
                fixed (byte* ptr = &NewName_[0])
                {
                    string str = Encoding.UTF8.GetString(new ReadOnlySpan<byte>(ptr, 0x10));
                    return str[..str.IndexOf('\0')];
                }
            }
        }

        public static RenameCharPkt Cast(byte[] data)
        {
            fixed (byte* pdata = &data[0])
            {
                return Marshal.PtrToStructure<RenameCharPkt>(new IntPtr(pdata));
            }
        }
    }
}
