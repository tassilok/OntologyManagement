using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using Filesystem_Module;
using System.IO;

namespace AudioPlayer_Module
{
    public partial class UserControl_AudioPlayer : UserControl
    {
        private IWavePlayer waveOut_Pri;
        private IWavePlayer waveOut_Sec;
        private IWavePlayer waveOut_Current;
        private WaveStream fileWaveStream_Pri;
        private WaveStream fileWaveStream_Sec;
        private WaveStream fileWaveStream_Current;
        private Action<float> setVolumeDelegate;

        private clsLocalConfig objLocalConfig;

        private List<clsMultimediaItem> OList_MediaItems;

        private clsFileWork objFileWork;
        private clsBlobConnection objBlobConnection;

        private bool priLoaded;

        private bool stoppedPressed;

        private int itemId;


        public void Clear_Media()
        {

            if (waveOut_Current != null)
            {
                stoppedPressed = true;
                waveOut_Current.Stop();
            }

            if (waveOut_Pri != null)
            {
                waveOut_Pri.Dispose();
                waveOut_Pri = null;
            }

            if (waveOut_Sec != null)
            {
                waveOut_Sec.Dispose();
                waveOut_Sec = null;
            }

            if (waveOut_Current != null)
            {
                waveOut_Current.Dispose();
                waveOut_Current = null;
            }

            if (fileWaveStream_Pri != null)
            {
                fileWaveStream_Pri.Dispose();
                fileWaveStream_Pri = null;
            }

            if (fileWaveStream_Sec != null)
            {
                fileWaveStream_Sec.Dispose();
                fileWaveStream_Sec = null;
            }

            if (fileWaveStream_Current != null)
            {
                fileWaveStream_Current.Dispose();
                fileWaveStream_Current = null;
            }
            

            Configure_Controls();
            
        }

        public UserControl_AudioPlayer(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;
            Initialize();
        }

        public UserControl_AudioPlayer(clsGlobals Globals)
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(Globals);
            Initialize();
        }

        public clsOntologyItem Initialize_MediaItem(List<clsMultimediaItem> OList_MediaItems)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            Clear_Media();

            itemId = 0;

            this.OList_MediaItems = OList_MediaItems;

            objOItem_Result = SaveFiles();

            Configure_Controls();

            return objOItem_Result;
        }

        private clsOntologyItem SaveFiles()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            OList_MediaItems.ForEach(mi => 
                mi.IsBlobFile = objFileWork.is_File_Blob(new clsOntologyItem { GUID = mi.ID_File, 
                Name = mi.Name_File,
                GUID_Parent = mi.ID_Parent_File,
                Type = objLocalConfig.Globals.Type_Object }));

            OList_MediaItems.ForEach(mi =>
                mi.Path_File = GetFilePath(new clsOntologyItem
                {
                    GUID = mi.ID_File,
                    Name = mi.Name_File,
                    GUID_Parent = mi.ID_Parent_File,
                    Type = objLocalConfig.Globals.Type_Object
                }, mi.IsBlobFile));


            return objOItem_Result;
        }

        private string GetFilePath(clsOntologyItem OItem_File, bool isBlobFile)
        {
            string filePath = "%Temp%\\" + objLocalConfig.Globals.NewGUID + Path.GetExtension(OItem_File.Name);
            filePath = Environment.ExpandEnvironmentVariables(filePath);

            if (isBlobFile)
            {
                var objOItem_Result = objBlobConnection.save_Blob_To_File(OItem_File, filePath, true);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                {
                    filePath = null;
                }

            }
            else
            {
                filePath = objFileWork.get_Path_FileSystemObject(OItem_File, false);
            }

            return filePath;
        }

        private void Initialize()
        {
            objFileWork = new clsFileWork(objLocalConfig.Globals);
            objBlobConnection = new clsBlobConnection(objLocalConfig.Globals);
            
        }

        private void CreateWaveOut()
        {
            CloseWaveOut();
            waveOut_Current = new WaveOut();
            waveOut_Current.PlaybackStopped += waveOut_PlaybackStopped;

            
           
        }

        void waveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            StoppedPlaying();
        }

        private void StoppedPlaying()
        {
            timer_Position.Stop();

            if (toolStripButton_AutoPlay.Checked && !stoppedPressed)
            {
                StartMediaItem();
            }
            stoppedPressed = false;
            Configure_Controls();
        }

        private void Configure_Controls()
        {
            toolStripButton_AutoPlay.Enabled = false;
            toolStripButton_First.Enabled = false;
            toolStripButton_Last.Enabled = false;
            toolStripButton_Next.Enabled = false;
            toolStripButton_Previous.Enabled = false;
            toolStripButton_Pause.Enabled = false;
            toolStripButton_Play.Enabled = false;
            toolStripButton_Stop.Enabled = false;
            

            if (waveOut_Current != null)
            {
                TimeSpan currentTime = fileWaveStream_Current == null ? TimeSpan.Zero : fileWaveStream_Current.CurrentTime;
                trackBar_Position.Value = fileWaveStream_Current != null ? Math.Min(trackBar_Position.Maximum, (int)(100 * currentTime.TotalSeconds / fileWaveStream_Current.TotalTime.TotalSeconds)) : 0;
            }
            else
            {
                trackBar_Position.Value = 0;
            }
            

            if (OList_MediaItems != null && OList_MediaItems.Count > 0)
            {
                toolStripButton_AutoPlay.Enabled = true;
                if (waveOut_Current != null && fileWaveStream_Current != null)
                {
                    if (waveOut_Current.PlaybackState == PlaybackState.Paused ||
                        waveOut_Current.PlaybackState == PlaybackState.Stopped)
                    {
                        toolStripButton_Play.Enabled = true;
                    }
                    else
                    {
                        toolStripButton_Stop.Enabled = true;
                        toolStripButton_Pause.Enabled = true;

                       
                    }
                    
                }
                else
                {
                    toolStripButton_Play.Enabled = true;
                    
                }
                

                if (OList_MediaItems.Count > 1)
                {
                    if (itemId > 0)
                    {
                        toolStripButton_First.Enabled = true;
                        toolStripButton_Previous.Enabled = true;
                    }

                    if (itemId < OList_MediaItems.Count - 1)
                    {
                        toolStripButton_Next.Enabled = true;
                        toolStripButton_Last.Enabled = true;
                    }
                }
            }

            toolStripLabel_ItemOfCount.Text = OList_MediaItems != null ? (itemId+1).ToString() + "/" + OList_MediaItems.Count.ToString() : "0/0";
            toolStripLabel_Position.Text = fileWaveStream_Current != null ? TimeSpan.FromSeconds(fileWaveStream_Current.CurrentTime.Hours * 3600 + fileWaveStream_Current.CurrentTime.Minutes * 60 + fileWaveStream_Current.CurrentTime.Seconds).ToString() : "00:00:00";

        }

        private void StartMediaItem(bool nextItem = true)
        {
            Configure_Controls();
            if (itemId < OList_MediaItems.Count)
            {
                if (waveOut_Current == waveOut_Pri)
                {
                    waveOut_Current = waveOut_Sec;
                    fileWaveStream_Current = fileWaveStream_Sec;
                }
                else
                {
                    waveOut_Current = waveOut_Pri;
                    fileWaveStream_Current = fileWaveStream_Pri;
                }

                timer_Position.Stop();

                var mediaItem = GetMediaItem(nextItem);

                if (mediaItem != null)
                {
                    var sampleProvider = InitializeNewWaveOut(mediaItem);

                    if (sampleProvider != null)
                    {
                        

                        if (toolStripButton_AutoPlay.Checked)
                        {
                            waveOut_Current.Play();
                            timer_Position.Start();
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show(this, "Die Mediendatei konnte nicht geöffnet werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            Configure_Controls();
        }

        private void CloseWaveOut()
        {
            timer_Position.Stop();
            if (waveOut_Current != null)
            {
                waveOut_Current.Stop();
            }
            if (fileWaveStream_Current != null)
            {
                // this one really closes the file and ACM conversion
                fileWaveStream_Current.Dispose();
                this.setVolumeDelegate = null;
            }
            if (waveOut_Current != null)
            {
                waveOut_Current.Dispose();
                waveOut_Current = null;
            }
        }

        private WaveStream CreateWaveStream(string fileName)
        {

            if (Path.GetExtension(fileName).ToLower() == "." + objLocalConfig.OItem_object_aiff.Name.ToLower())
            {
                return new AiffFileReader(fileName);
            }
            else if (Path.GetExtension(fileName).ToLower() == "." + objLocalConfig.OItem_object_mp3.Name.ToLower())
            {
                return new Mp3FileReader(fileName);
            }
            else if (Path.GetExtension(fileName).ToLower() == "." + objLocalConfig.OItem_object_wav.Name.ToLower())
            {
                WaveStream readerStream = new WaveFileReader(fileName);
                if (readerStream.WaveFormat.Encoding != WaveFormatEncoding.Pcm && readerStream.WaveFormat.Encoding != WaveFormatEncoding.IeeeFloat)
                {
                    readerStream = WaveFormatConversionStream.CreatePcmStream(readerStream);
                    //readerStream = new BlockAlignReductionStream(readerStream);
                }

                return readerStream;
            }
            else
            {
                return null;
            }

        }


        private ISampleProvider CreateInputStream(string fileName)
        {


            fileWaveStream_Current = CreateWaveStream(fileName);

            if (fileWaveStream_Current != null)
            {
                var waveChannel = new SampleChannel(fileWaveStream_Current, true);
                this.setVolumeDelegate = (vol) => waveChannel.Volume = vol;

                waveChannel.PreVolumeMeter += OnPreVolumeMeter;

                var postVolumeMeter = new MeteringSampleProvider(waveChannel);
                postVolumeMeter.StreamVolume += OnPostVolumeMeter;

                SetVolume();

                return postVolumeMeter;
            }
            else
            {
                return null;
            }

            
        }

        void OnPreVolumeMeter(object sender, StreamVolumeEventArgs e)
        {
            // we know it is stereo
            waveformPainter_Left.AddMax(e.MaxSampleValues[0]);
            waveformPainter_Right.AddMax(e.MaxSampleValues[1]);
        }

        void OnPostVolumeMeter(object sender, StreamVolumeEventArgs e)
        {
            // we know it is stereo
            volumeMeter_Left.Amplitude = e.MaxSampleValues[0];
            volumeMeter_Right.Amplitude = e.MaxSampleValues[1];
        }

       
        private void timer_Position_Tick(object sender, EventArgs e)
        {
            if (waveOut_Current != null)
            {
                TimeSpan currentTime = fileWaveStream_Current.CurrentTime;
                trackBar_Position.Value = Math.Min(trackBar_Position.Maximum, (int)(100 * currentTime.TotalSeconds / fileWaveStream_Current.TotalTime.TotalSeconds));
            }
            else
            {
                trackBar_Position.Value = 0;
            }
            toolStripLabel_Position.Text = fileWaveStream_Current != null ? TimeSpan.FromSeconds(fileWaveStream_Current.CurrentTime.Hours * 3600 + fileWaveStream_Current.CurrentTime.Minutes * 60 + fileWaveStream_Current.CurrentTime.Seconds).ToString() : "00:00:00";
            toolStripButton_Play.Enabled = waveOut_Current != null ? waveOut_Current.PlaybackState != PlaybackState.Playing : OList_MediaItems != null ? OList_MediaItems.Any() ? true: false : false;
            toolStripButton_Pause.Enabled = waveOut_Current != null ? waveOut_Current.PlaybackState == PlaybackState.Playing : false;
        }


        private clsMultimediaItem GetMediaItem(bool next = false)
        {

            if (next)
            {
                itemId++;
            }
            if (itemId < OList_MediaItems.Count)
            {
                var multimediaItem = OList_MediaItems[itemId];
                if (multimediaItem.Path_File == null)
                {
                    itemId++;
                    multimediaItem = GetMediaItem();
                }

                return multimediaItem;
            }
            else
            {
                return null;
            }
        }

        private void toolStripButton_Play_Click(object sender, EventArgs e)
        {
            
            if (waveOut_Current != null)
            {
                waveOut_Current.Play();
                timer_Position.Start();
            }
            else
            {

                timer_Position.Stop();

                var mediaItem = GetMediaItem();

                if (mediaItem != null)
                {
                    if (priLoaded)
                    {
                        waveOut_Current = waveOut_Sec;
                        fileWaveStream_Current = fileWaveStream_Sec;
                        priLoaded = true;
                    }
                    else
                    {
                        waveOut_Current = waveOut_Pri;
                        fileWaveStream_Current = fileWaveStream_Pri;
                        priLoaded = false;
                    }


                    var sampleProvider = InitializeNewWaveOut(mediaItem);

                    if (sampleProvider != null)
                    {
                        waveOut_Current.Play();
                        timer_Position.Start();
                    }
                    else
                    {
                        MessageBox.Show(this, "Die Mediendatei konnte nicht geöffnet werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    
                }
                else
                {
                    MessageBox.Show(this, "Es konnte kein MediaItem ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }


            Configure_Controls();
        }

        private ISampleProvider InitializeNewWaveOut(clsMultimediaItem mediaItem)
        {
            CreateWaveOut();

            ISampleProvider sampleProvider = null;
            try
            {
                sampleProvider = CreateInputStream(mediaItem.Path_File);
                try
                {
                    waveOut_Current.Init(sampleProvider);

                }
                catch (Exception initException)
                {
                    sampleProvider = null;
                }
            }
            catch (Exception createException)
            {
                sampleProvider = null;
                
            }

            return sampleProvider;
        }

        private void toolStripButton_Pause_Click(object sender, EventArgs e)
        {
            timer_Position.Stop();
            waveOut_Current.Pause();
            Configure_Controls();
        }

        private void toolStripButton_Stop_Click(object sender, EventArgs e)
        {
            timer_Position.Stop();
            stoppedPressed = true;
            waveOut_Current.Stop();
            Configure_Controls();
        }

        private void toolStripButton_First_Click(object sender, EventArgs e)
        {
            

            itemId = 0;

            NavigationItems();

        }

        private void NavigationItems()
        {
            if (waveOut_Current != null)
            {
                if (waveOut_Current.PlaybackState == PlaybackState.Playing)
                {
                    stoppedPressed = true;
                    waveOut_Current.Stop();
                }

            }

            
            StartMediaItem(false);
            

            
        }

        private void toolStripButton_Previous_Click(object sender, EventArgs e)
        {
            if (itemId > 0)
            {
                itemId--;

                NavigationItems();
            }
        }

        private void toolStripButton_Next_Click(object sender, EventArgs e)
        {
            if (itemId < OList_MediaItems.Count-1)
            {
                itemId++;

                NavigationItems();
            }
        }

        private void toolStripButton_Last_Click(object sender, EventArgs e)
        {
            if (itemId < OList_MediaItems.Count - 1)
            {
                itemId = OList_MediaItems.Count-1;

                NavigationItems();
            }
        }

        private void volumeSlider_VolumeChanged(object sender, EventArgs e)
        {
            SetVolume();
        }

        private void SetVolume()
        {
            if (setVolumeDelegate != null)
            {
                setVolumeDelegate(volumeSlider.Volume);
            }
        }

        private void trackBar_Position_Scroll(object sender, EventArgs e)
        {
            if (waveOut_Current != null)
            {
                fileWaveStream_Current.CurrentTime = TimeSpan.FromSeconds(fileWaveStream_Current.TotalTime.TotalSeconds * trackBar_Position.Value / 100.0);
                toolStripLabel_Position.Text = fileWaveStream_Current != null ? TimeSpan.FromSeconds(fileWaveStream_Current.CurrentTime.Hours * 3600 + fileWaveStream_Current.CurrentTime.Minutes * 60 + fileWaveStream_Current.CurrentTime.Seconds).ToString() : "00:00:00";
            }
        }
    }
}
