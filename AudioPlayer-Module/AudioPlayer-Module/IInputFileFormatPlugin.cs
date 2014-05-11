﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace AudioPlayer_Module
{
    public interface IInputFileFormatPlugin
    {
        string Name { get; }
        string Extension { get; }
        WaveStream CreateWaveStream(string fileName);
    }
}
