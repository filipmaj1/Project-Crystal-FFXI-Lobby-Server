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

using System.Runtime.InteropServices;

namespace Crystal.FFXILobbyServer.Network.Models
{
    [StructLayout(LayoutKind.Sequential, Size = SIZE)]
    public unsafe struct CharaInfo
    {
        public const int SIZE = 0x60;

        public ushort RaceNum;
        public byte MJobNum;
        public byte SJobNum;
        public ushort FaceNum;
        public byte TownNum;
        public byte GenFlag;
        public byte HairNum;
        public byte Size;
        public ushort WorldNum;

        public ushort FaceModelId;
        public ushort HeadModelId;
        public ushort BodyModelId;
        public ushort HandsModelId;
        public ushort LegsModelId;
        public ushort FeetModelId;
        public ushort MainWeaponModelId;
        public ushort SubWeaponModelId;

        public byte ZoneNumLow;
        public byte MJobLevel;
        public byte AnonStatusFlag;
        public byte GMCallCounter;
        public ushort Version;
        public byte Skill1;
        public byte ZoneNumHigh;

        public byte SandOriaRank;
        public byte BastokRank;
        public byte WindhurstRank;

        public byte ErrorCounter;
        public ushort SandOriaFame;
        public ushort BastokFame;
        public ushort WindhurstFame;
        public ushort NorgFame;

        public uint PlayTime;
        public uint UnlockedJobs;

        public fixed byte JobLevels[0x10];

        public uint FirstLoginDate;
        public uint Gold;

        public byte Skill2;
        public byte Skill3;
        public byte Skill4;
        public byte Skill5;

        public uint ChatCounter;
        public uint PartyCounter;

        public byte Skill6;
        public byte Skill7;
        public byte Skill8;
        public byte Skill9;
    }
}
