using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using EGMGame.Library;

namespace EGMGame
{
    public class XboxManager
    {
        const string projectExt = ".csproj";

        static string gameLibXGUID = System.Guid.NewGuid().ToString("D").ToUpper();
        static string gameLibWGUID = System.Guid.NewGuid().ToString("D").ToUpper();
        static string egmGameGUID = System.Guid.NewGuid().ToString("D").ToUpper();
        static string contentGUID = System.Guid.NewGuid().ToString("D").ToUpper();
        static string content2GUID = System.Guid.NewGuid().ToString("D").ToUpper();

        public static void CreateXboxProject(Project project)
        {

            if (!Directory.Exists(project.Location + @"\Xbox"))
                Directory.CreateDirectory(project.Location + @"\Xbox");
            //if (!Directory.Exists(project.Location))
            //Directory.CreateDirectory(project.Location + @"\XboxContent");

            string path = project.Location + @"\Xbox\GameLibrary\GameLibrary" + projectExt;


            if (!Directory.Exists(project.Location + @"\Xbox\GameLibrary"))
                Directory.CreateDirectory(project.Location + @"\Xbox\GameLibrary");
            #region Game Library
            using (StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                file.WriteLine("<Project DefaultTargets=\"Build\" ToolsVersion=\"4.0\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
                file.WriteLine("  <PropertyGroup>");
                file.WriteLine("    <ProjectGuid>{" + gameLibWGUID + "}</ProjectGuid>");
                file.WriteLine("    <ProjectTypeGuids>{6D335F3A-9D43-41b4-9D22-F6F17C4BE596};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}</ProjectTypeGuids>");
                file.WriteLine("    <Configuration Condition=\" '$(Configuration)' == '' \">Debug</Configuration>");
                file.WriteLine("    <Platform Condition=\" '$(Platform)' == '' \">Xbox 360</Platform>");
                file.WriteLine("    <OutputType>Library</OutputType>");
                file.WriteLine("    <AppDesignerFolder>Properties</AppDesignerFolder>");
                file.WriteLine("    <RootNamespace>GameLibrary</RootNamespace>");
                file.WriteLine("    <AssemblyName>GameLibrary</AssemblyName>");
                file.WriteLine("    <TargetFrameworkVersion>v4.0</TargetFrameworkVersion>");
                file.WriteLine("    <TargetFrameworkProfile>Client</TargetFrameworkProfile>");
                file.WriteLine("    <XnaFrameworkVersion>v4.0</XnaFrameworkVersion>");
                file.WriteLine("    <XnaPlatform>Xbox 360</XnaPlatform>");
                file.WriteLine("    <XnaProfile>HiDef</XnaProfile>");
                file.WriteLine("    <XnaCrossPlatformGroupID>5e94853b-bc02-40df-ae88-069a0fa78ead</XnaCrossPlatformGroupID>");
                file.WriteLine("    <XnaOutputType>Library</XnaOutputType>");
                file.WriteLine("      </PropertyGroup>");
                file.WriteLine("      <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|Xbox 360' \">");
                file.WriteLine("    <DebugSymbols>true</DebugSymbols>");
                file.WriteLine("    <DebugType>full</DebugType>");
                file.WriteLine("    <Optimize>false</Optimize>");
                file.WriteLine("    <OutputPath>bin\\Xbox 360\\Debug</OutputPath>");
                file.WriteLine("    <DefineConstants>DEBUG;TRACE;XBOX;XBOX360;XNA</DefineConstants>");
                file.WriteLine("    <ErrorReport>prompt</ErrorReport>");
                file.WriteLine("    <WarningLevel>4</WarningLevel>");
                file.WriteLine("    <NoStdLib>true</NoStdLib>");
                file.WriteLine("    <UseVSHostingProcess>false</UseVSHostingProcess>");
                file.WriteLine("    <XnaCompressContent>true</XnaCompressContent>");
                file.WriteLine("  </PropertyGroup>");
                file.WriteLine("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|Xbox 360' \">");
                file.WriteLine("    <DebugType>pdbonly</DebugType>");
                file.WriteLine("    <Optimize>true</Optimize>");
                file.WriteLine("    <OutputPath>bin\\Xbox 360\\Release</OutputPath>");
                file.WriteLine("    <DefineConstants>TRACE;XBOX;XBOX360;XNA</DefineConstants>");
                file.WriteLine("    <ErrorReport>prompt</ErrorReport>");
                file.WriteLine("    <WarningLevel>4</WarningLevel>");
                file.WriteLine("    <NoStdLib>true</NoStdLib>");
                file.WriteLine("    <UseVSHostingProcess>false</UseVSHostingProcess>");
                file.WriteLine("    <XnaCompressContent>true</XnaCompressContent>");
                file.WriteLine("  </PropertyGroup>");
                file.WriteLine("  <ItemGroup>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Game\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Graphics\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.GamerServices\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("          </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Xact\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("          </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Video\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("          </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Avatar\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("          </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Net\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("          </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Storage\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("          </Reference>");
                file.WriteLine("    <Reference Include=\"mscorlib\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("          </Reference>");
                file.WriteLine("    <Reference Include=\"System\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("          </Reference>");
                file.WriteLine("    <Reference Include=\"System.Xml\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("          </Reference>");
                file.WriteLine("    <Reference Include=\"System.Core\">");
                file.WriteLine("      <RequiredTargetFramework>4.0</RequiredTargetFramework>");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("          </Reference>");
                file.WriteLine("    <Reference Include=\"System.Xml.Linq\">");
                file.WriteLine("      <RequiredTargetFramework>4.0</RequiredTargetFramework>");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("          </Reference>");
                file.WriteLine("    <Reference Include=\"System.Net\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("          </Reference>");
                file.WriteLine("  </ItemGroup>");
                file.WriteLine("  <ItemGroup>");
                foreach (SourceFile source in project.SourceFiles)
                {
                    if (!source.Path.Contains(@"\Game.cs") && !source.Path.Contains("AssemblyInfo.cs"))
                    {
                        file.WriteLine("    <Compile Include=\"..\\.." + source.Path + "\">");
                        file.WriteLine("      <Link>" + source.Path.Replace(@"\Source", "Source") + "</Link>");
                        file.WriteLine("    </Compile>");
                    }
                }
                file.WriteLine("    <Compile Include=\"Properties\\AssemblyInfo.cs\" />");
                file.WriteLine("  </ItemGroup>");
                file.WriteLine("  <Import Project=\"$(MSBuildBinPath)\\Microsoft.CSharp.targets\" />");
                file.WriteLine("  <Import Project=\"$(MSBuildExtensionsPath)\\Microsoft\\XNA Game Studio\\Microsoft.Xna.GameStudio.targets\" />");
                file.WriteLine("  <!--");
                file.WriteLine("      To modify your build process, add your task inside one of the targets below and uncomment it. ");
                file.WriteLine("      Other similar extension points exist, see Microsoft.Common.targets.");
                file.WriteLine("      <Target Name=\"BeforeBuild\">");
                file.WriteLine("      </Target>");
                file.WriteLine("      <Target Name=\"AfterBuild\">");
                file.WriteLine("      </Target>");
                file.WriteLine("    -->");
                file.WriteLine("</Project>");
                file.Close();
            }
            #endregion

            path = project.Location + @"\Xbox\GameLibrary\GameLibrary(Win)" + projectExt;
            #region Game Library (win)
            using (StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                file.WriteLine("<Project DefaultTargets=\"Build\" ToolsVersion=\"4.0\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
                file.WriteLine("  <PropertyGroup>");
                file.WriteLine("    <ProjectGuid>{" + gameLibWGUID + "}</ProjectGuid>");
                file.WriteLine("    <ProjectTypeGuids>{6D335F3A-9D43-41b4-9D22-F6F17C4BE596};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}</ProjectTypeGuids>");
                file.WriteLine("    <Configuration Condition=\" '$(Configuration)' == '' \">Debug</Configuration>");
                file.WriteLine("    <Platform Condition=\" '$(Platform)' == '' \">x86</Platform>");
                file.WriteLine("    <OutputType>Library</OutputType>");
                file.WriteLine("    <AppDesignerFolder>Properties</AppDesignerFolder>");
                file.WriteLine("    <RootNamespace>GameLibrary</RootNamespace>");
                file.WriteLine("    <AssemblyName>GameLibrary</AssemblyName>");
                file.WriteLine("    <TargetFrameworkVersion>v4.0</TargetFrameworkVersion>");
                file.WriteLine("    <TargetFrameworkProfile></TargetFrameworkProfile>");
                file.WriteLine("    <XnaFrameworkVersion>v4.0</XnaFrameworkVersion>");
                file.WriteLine("    <XnaPlatform>Windows</XnaPlatform>");
                file.WriteLine("    <XnaProfile>HiDef</XnaProfile>");
                file.WriteLine("    <XnaCrossPlatformGroupID>5e94853b-bc02-40df-ae88-069a0fa78ead</XnaCrossPlatformGroupID>");
                file.WriteLine("    <XnaOutputType>Library</XnaOutputType>");
                file.WriteLine("    <PublishUrl>publish\\</PublishUrl>");
                file.WriteLine("    <Install>true</Install>");
                file.WriteLine("    <InstallFrom>Disk</InstallFrom>");
                file.WriteLine("    <UpdateEnabled>false</UpdateEnabled>");
                file.WriteLine("    <UpdateMode>Foreground</UpdateMode>");
                file.WriteLine("    <UpdateInterval>7</UpdateInterval>");
                file.WriteLine("    <UpdateIntervalUnits>Days</UpdateIntervalUnits>");
                file.WriteLine("    <UpdatePeriodically>false</UpdatePeriodically>");
                file.WriteLine("    <UpdateRequired>false</UpdateRequired>");
                file.WriteLine("    <MapFileExtensions>true</MapFileExtensions>");
                file.WriteLine("    <ApplicationRevision>0</ApplicationRevision>");
                file.WriteLine("    <ApplicationVersion>1.0.0.%2a</ApplicationVersion>");
                file.WriteLine("    <IsWebBootstrapper>false</IsWebBootstrapper>");
                file.WriteLine("    <UseApplicationTrust>false</UseApplicationTrust>");
                file.WriteLine("    <BootstrapperEnabled>true</BootstrapperEnabled>");
                file.WriteLine("  </PropertyGroup>");
                file.WriteLine("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|x86' \">");
                file.WriteLine("    <OutputPath>bin\\x86\\Debug</OutputPath>");
                file.WriteLine("    <ErrorReport>prompt</ErrorReport>");
                file.WriteLine("    <WarningLevel>4</WarningLevel>");
                file.WriteLine("    <NoStdLib>true</NoStdLib>");
                file.WriteLine("    <UseVSHostingProcess>false</UseVSHostingProcess>");
                file.WriteLine("    <DebugSymbols>true</DebugSymbols>");
                file.WriteLine("    <DebugType>full</DebugType>");
                file.WriteLine("    <Optimize>false</Optimize>");
                file.WriteLine("    <DefineConstants>DEBUG;TRACE;WINDOWS;XNA</DefineConstants>");
                file.WriteLine("    <PlatformTarget>x86</PlatformTarget>");
                file.WriteLine("    <XnaCompressContent>false</XnaCompressContent>");
                file.WriteLine("  </PropertyGroup>");
                file.WriteLine("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|x86' \">");
                file.WriteLine("    <OutputPath>bin\\x86\\Release</OutputPath>");
                file.WriteLine("    <ErrorReport>prompt</ErrorReport>");
                file.WriteLine("    <WarningLevel>4</WarningLevel>");
                file.WriteLine("    <NoStdLib>true</NoStdLib>");
                file.WriteLine("    <UseVSHostingProcess>false</UseVSHostingProcess>");
                file.WriteLine("    <DebugType>pdbonly</DebugType>");
                file.WriteLine("    <Optimize>true</Optimize>");
                file.WriteLine("    <DefineConstants>TRACE;WINDOWS;XNA</DefineConstants>");
                file.WriteLine("    <PlatformTarget>x86</PlatformTarget>");
                file.WriteLine("    <XnaCompressContent>true</XnaCompressContent>");
                file.WriteLine("  </PropertyGroup>");
                file.WriteLine("  <ItemGroup>");
                file.WriteLine("    <BootstrapperPackage Include=\".NETFramework,Version=v4.0,Profile=Client\">");
                file.WriteLine("      <Visible>False</Visible>");
                file.WriteLine("      <ProductName>Microsoft .NET Framework 4 Client Profile %28x86 and x64%29</ProductName>");
                file.WriteLine("      <Install>true</Install>");
                file.WriteLine("    </BootstrapperPackage>");
                file.WriteLine("    <BootstrapperPackage Include=\"Microsoft.Net.Client.3.5\">");
                file.WriteLine("      <Visible>False</Visible>");
                file.WriteLine("      <ProductName>.NET Framework 3.5 SP1 Client Profile</ProductName>");
                file.WriteLine("      <Install>false</Install>");
                file.WriteLine("    </BootstrapperPackage>");
                file.WriteLine("    <BootstrapperPackage Include=\"Microsoft.Net.Framework.3.5.SP1\">");
                file.WriteLine("      <Visible>False</Visible>");
                file.WriteLine("      <ProductName>.NET Framework 3.5 SP1</ProductName>");
                file.WriteLine("      <Install>false</Install>");
                file.WriteLine("    </BootstrapperPackage>");
                file.WriteLine("    <BootstrapperPackage Include=\"Microsoft.Windows.Installer.3.1\">");
                file.WriteLine("      <Visible>False</Visible>");
                file.WriteLine("      <ProductName>Windows Installer 3.1</ProductName>");
                file.WriteLine("      <Install>true</Install>");
                file.WriteLine("    </BootstrapperPackage>");
                file.WriteLine("    <BootstrapperPackage Include=\"Microsoft.Xna.Framework.4.0\">");
                file.WriteLine("      <Visible>False</Visible>");
                file.WriteLine("      <ProductName>Microsoft XNA Framework Redistributable 4.0</ProductName>");
                file.WriteLine("      <Install>true</Install>");
                file.WriteLine("    </BootstrapperPackage>");
                file.WriteLine("  </ItemGroup>");
                file.WriteLine("  <ItemGroup>");
                foreach (SourceFile source in project.SourceFiles)
                {
                    if (!source.Path.Contains(@"\Game.cs") && !source.Path.Contains("AssemblyInfo.cs"))
                    {
                        file.WriteLine("    <Compile Include=\"..\\.." + source.Path + "\">");
                        file.WriteLine("      <Link>" + source.Path.Replace(@"\Source", "Source") + "</Link>");
                        file.WriteLine("    </Compile>");
                    }
                }
                file.WriteLine("    <Compile Include=\"Properties\\AssemblyInfo.cs\" />");
                file.WriteLine("  </ItemGroup>");
                file.WriteLine("  <ItemGroup>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=x86\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Avatar, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=x86\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=x86\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Content.Pipeline, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=x86\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.GamerServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=x86\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=x86\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Net, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=x86\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Storage, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=x86\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Video, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=x86\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Xact, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=x86\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"mscorlib\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"System\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"System.Core\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"System.Net\" />");
                file.WriteLine("    <Reference Include=\"System.Xml\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"System.Xml.Linq\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("  </ItemGroup>");
                file.WriteLine("  <Import Project=\"$(MSBuildBinPath)\\Microsoft.CSharp.targets\" />");
                file.WriteLine("  <Import Project=\"$(MSBuildExtensionsPath)\\Microsoft\\XNA Game Studio\\Microsoft.Xna.GameStudio.targets\" />");
                file.WriteLine("  <!--");
                file.WriteLine("      To modify your build process, add your task inside one of the targets below and uncomment it. ");
                file.WriteLine("      Other similar extension points exist, see Microsoft.Common.targets.");
                file.WriteLine("      <Target Name=\"BeforeBuild\">");
                file.WriteLine("      </Target>");
                file.WriteLine("      <Target Name=\"AfterBuild\">");
                file.WriteLine("      </Target>");
                file.WriteLine("    -->");
                file.WriteLine("</Project>");

                file.Close();
            }
            #endregion

            path = project.Location + @"\Xbox\EGMGame\EGMGame" + projectExt;

            if (!Directory.Exists(project.Location + @"\Xbox\EGMGame"))
                Directory.CreateDirectory(project.Location + @"\Xbox\EGMGame");
            #region Game
            // Create Content Project
            using (StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                file.WriteLine("<Project DefaultTargets=\"Build\" ToolsVersion=\"4.0\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
                file.WriteLine("  <PropertyGroup>");
                file.WriteLine("    <ProjectGuid>{" + egmGameGUID + "}</ProjectGuid>");
                file.WriteLine("    <ProjectTypeGuids>{6D335F3A-9D43-41b4-9D22-F6F17C4BE596};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}</ProjectTypeGuids>");
                file.WriteLine("    <Configuration Condition=\" '$(Configuration)' == '' \">Debug</Configuration>");
                file.WriteLine("    <Platform Condition=\" '$(Platform)' == '' \">Xbox 360</Platform>");
                file.WriteLine("    <OutputType>Exe</OutputType>");
                file.WriteLine("    <AppDesignerFolder>Properties</AppDesignerFolder>");
                file.WriteLine("    <RootNamespace>EGMGame</RootNamespace>");
                file.WriteLine("    <AssemblyName>EGMGame</AssemblyName>");
                file.WriteLine("    <TargetFrameworkVersion>v4.0</TargetFrameworkVersion>");
                file.WriteLine("    <TargetFrameworkProfile>Client</TargetFrameworkProfile>");
                file.WriteLine("    <XnaFrameworkVersion>v4.0</XnaFrameworkVersion>");
                file.WriteLine("    <XnaPlatform>Xbox 360</XnaPlatform>");
                file.WriteLine("    <XnaProfile>HiDef</XnaProfile>");
                file.WriteLine("    <XnaCrossPlatformGroupID>18ac6ea9-32e9-4121-8933-5c7f14e0c654</XnaCrossPlatformGroupID>");
                file.WriteLine("    <XnaOutputType>Game</XnaOutputType>");
                file.WriteLine("    <ApplicationIcon></ApplicationIcon>");
                file.WriteLine("    <Thumbnail>GameThumbnail.png</Thumbnail>");
                file.WriteLine("  </PropertyGroup>");
                file.WriteLine("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|Xbox 360' \">");
                file.WriteLine("    <DebugSymbols>true</DebugSymbols>");
                file.WriteLine("    <DebugType>full</DebugType>");
                file.WriteLine("    <Optimize>false</Optimize>");
                file.WriteLine("    <OutputPath>bin\\Xbox 360\\Debug</OutputPath>");
                file.WriteLine("    <DefineConstants>DEBUG;TRACE;XBOX;XBOX360;XNA</DefineConstants>");
                file.WriteLine("    <ErrorReport>prompt</ErrorReport>");
                file.WriteLine("    <WarningLevel>4</WarningLevel>");
                file.WriteLine("    <NoStdLib>true</NoStdLib>");
                file.WriteLine("    <UseVSHostingProcess>false</UseVSHostingProcess>");
                file.WriteLine("    <XnaCompressContent>true</XnaCompressContent>");
                file.WriteLine("  </PropertyGroup>");
                file.WriteLine("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|Xbox 360' \">");
                file.WriteLine("    <DebugType>pdbonly</DebugType>");
                file.WriteLine("    <Optimize>true</Optimize>");
                file.WriteLine("    <OutputPath>bin\\Xbox 360\\Release</OutputPath>");
                file.WriteLine("    <DefineConstants>TRACE;XBOX;XBOX360;XNA</DefineConstants>");
                file.WriteLine("    <ErrorReport>prompt</ErrorReport>");
                file.WriteLine("    <WarningLevel>4</WarningLevel>");
                file.WriteLine("    <NoStdLib>true</NoStdLib>");
                file.WriteLine("    <UseVSHostingProcess>false</UseVSHostingProcess>");
                file.WriteLine("    <XnaCompressContent>true</XnaCompressContent>");
                file.WriteLine("  </PropertyGroup>");
                file.WriteLine("  <ItemGroup>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Game\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Graphics\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.GamerServices\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Xact\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("     <Reference Include=\"Microsoft.Xna.Framework.Video\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("     </Reference>");
                file.WriteLine("     <Reference Include=\"Microsoft.Xna.Framework.Avatar\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("     </Reference>");
                file.WriteLine("     <Reference Include=\"Microsoft.Xna.Framework.Net\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("     </Reference>");
                file.WriteLine("     <Reference Include=\"Microsoft.Xna.Framework.Storage\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("     </Reference>");
                file.WriteLine("     <Reference Include=\"mscorlib\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("     </Reference>");
                file.WriteLine("     <Reference Include=\"System\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("     </Reference>");
                file.WriteLine("     <Reference Include=\"System.Xml\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("     </Reference>");
                file.WriteLine("     <Reference Include=\"System.Core\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("     </Reference>");
                file.WriteLine("     <Reference Include=\"System.Xml.Linq\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("     </Reference>");
                file.WriteLine("     <Reference Include=\"System.Net\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("  </ItemGroup>");
                file.WriteLine("  <ItemGroup>");
                foreach (SourceFile source in project.SourceFiles)
                {
                    if (source.Path.Contains(@"\Game.cs") && !source.Path.Contains("AssemblyInfo.cs"))
                    {
                        file.WriteLine("    <Compile Include=\"..\\.." + source.Path + "\">");
                        file.WriteLine("      <Link>" + source.Path.Replace(@"\Source", "Source") + "</Link>");
                        file.WriteLine("    </Compile>");
                        break;
                    }
                }
                file.WriteLine("    <Compile Include=\"Properties\\AssemblyInfo.cs\" />");
                file.WriteLine("  </ItemGroup>");
                file.WriteLine("  <ItemGroup>");
                file.WriteLine("    <ProjectReference Include=\"..\\GameLibrary\\GameLibrary.csproj\">");
                file.WriteLine("      <Project>{" + gameLibXGUID + "}</Project>");
                file.WriteLine("      <Name>GameLibrary</Name>");
                file.WriteLine("    </ProjectReference>");
                file.WriteLine("    <ProjectReference Include=\"..\\..\\Materials\\Content.contentproj\">");
                file.WriteLine("      <Project>{" + contentGUID + "}</Project>");
                file.WriteLine("      <Name>Content</Name>");
                file.WriteLine("      <XnaReferenceType>Content</XnaReferenceType>");
                file.WriteLine("    </ProjectReference>");
                file.WriteLine("    <ProjectReference Include=\"..\\..\\ContentData.contentproj\">");
                file.WriteLine("      <Project>{" + content2GUID + "}</Project>");
                file.WriteLine("      <Name>ContentData</Name>");
                file.WriteLine("      <XnaReferenceType>Content</XnaReferenceType>");
                file.WriteLine("    </ProjectReference>");
                file.WriteLine("  </ItemGroup>");
                file.WriteLine("   <Import Project=\"$(MSBuildBinPath)\\Microsoft.CSharp.targets\" />");
                file.WriteLine("   <Import Project=\"$(MSBuildExtensionsPath)\\Microsoft\\XNA Game Studio\\Microsoft.Xna.GameStudio.targets\" />");
                file.WriteLine("   <!--");
                file.WriteLine("       To modify your build process, add your task inside one of the targets below and uncomment it. ");
                file.WriteLine("       Other similar extension points exist, see Microsoft.Common.targets.");
                file.WriteLine("       <Target Name=\"BeforeBuild\">");
                file.WriteLine("       </Target>");
                file.WriteLine("       <Target Name=\"AfterBuild\">");
                file.WriteLine("       </Target>");
                file.WriteLine("     -->");
                file.WriteLine(" </Project>");

                file.Close();
            }
            #endregion

            CreateAssemblyCSEGMGAME(project.Location + @"\Xbox\EGMGame");
            CreateAssemblyCSEGMLIB(project.Location + @"\Xbox\GameLibrary");


            path = project.Location + @"\Materials\Content.contentproj";
            #region Content
            // Create Content Project
            using (StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine("<Project DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\" ToolsVersion=\"4.0\">");
                file.WriteLine("  <PropertyGroup>");
                file.WriteLine("    <ProjectGuid>{" + contentGUID + "}</ProjectGuid>");
                file.WriteLine("    <ProjectTypeGuids>{96E2B04D-8817-42c6-938A-82C39BA4D311};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}</ProjectTypeGuids>");
                file.WriteLine("    <Configuration Condition=\" '$(Configuration)' == '' \">Debug</Configuration>");
                file.WriteLine("    <Platform Condition=\" '$(Platform)' == '' \">x86</Platform>");
                file.WriteLine("    <OutputType>Library</OutputType>");
                file.WriteLine("    <AppDesignerFolder>Properties</AppDesignerFolder>");
                file.WriteLine("    <TargetFrameworkVersion>v4.0</TargetFrameworkVersion>");
                file.WriteLine("    <XnaFrameworkVersion>v4.0</XnaFrameworkVersion>");
                file.WriteLine("    <PlatformTarget>x86</PlatformTarget>");
                file.WriteLine("    <XNAContentPipelineTargetProfile>Reach</XNAContentPipelineTargetProfile>");
                file.WriteLine("    <OutputPath>bin\\$(Platform)\\$(Configuration)</OutputPath>");
                file.WriteLine("    <ContentRootDirectory>Content</ContentRootDirectory>");
                file.WriteLine("  </PropertyGroup>");
                file.WriteLine("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|Xbox 360' \">");
                file.WriteLine("    <XnaPlatform>x86</XnaPlatform>");
                file.WriteLine("  </PropertyGroup>");
                file.WriteLine("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|Xbox 360' \">");
                file.WriteLine("    <XnaPlatform>x86</XnaPlatform>");
                file.WriteLine("  </PropertyGroup>");
                file.WriteLine("  <PropertyGroup>");
                file.WriteLine("    <RootNamespace>Content</RootNamespace>");
                file.WriteLine("  </PropertyGroup>");
                file.WriteLine("  <ItemGroup>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Content.Pipeline.EffectImporter, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=MSIL\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Content.Pipeline.FBXImporter, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=MSIL\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Content.Pipeline.TextureImporter, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=MSIL\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Content.Pipeline.XImporter, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=MSIL\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Content.Pipeline.AudioImporters, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=MSIL\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Content.Pipeline.VideoImporters, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=MSIL\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("  </ItemGroup>");

                file.WriteLine("   <ItemGroup>");
                foreach (MaterialData material in GameData.Materials.Values)
                {
                    if (File.Exists(project.Location + "\\" + material.FileName))
                    {
                        string name = material.FileName;
                        file.WriteLine("     <Compile Include=\"" + name.Remove(0, 10) + "\">"); // Compile Include="001-Chest.png"
                        file.WriteLine("       <Name>" + Path.GetFileName(material.FileName) + "</Name>"); // <Name>001-Chest</Name>
                        file.WriteLine("       <Importer>" + GetImporter(Path.GetExtension(material.FileName)) + "</Importer>");
                        file.WriteLine("       <Processor>" + GetProcessor(Path.GetExtension(material.FileName)) + "</Processor>");
                        file.WriteLine("     </Compile>");
                    }
                }

                file.WriteLine("   </ItemGroup>");

                file.WriteLine("  <Import Project=\"$(MSBuildExtensionsPath)\\Microsoft\\XNA Game Studio\\$(XnaFrameworkVersion)\\Microsoft.Xna.GameStudio.ContentPipeline.targets\" />");
                file.WriteLine("");
                file.WriteLine("  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. ");
                file.WriteLine("       Other similar extension points exist, see Microsoft.Common.targets.");
                file.WriteLine("  <Target Name=\"BeforeBuild\">");
                file.WriteLine("  </Target>");
                file.WriteLine("  <Target Name=\"AfterBuild\">");
                file.WriteLine("  </Target>");
                file.WriteLine("  -->");
                file.WriteLine("");
                file.WriteLine("</Project>");
            }
            #endregion


            path = project.Location + @"\ContentData.contentproj";
            #region Content
            // Create Content Project
            using (StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine("<Project DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\" ToolsVersion=\"4.0\">");
                file.WriteLine("  <PropertyGroup>");
                file.WriteLine("    <ProjectGuid>{" + content2GUID + "}</ProjectGuid>");
                file.WriteLine("    <ProjectTypeGuids>{96E2B04D-8817-42c6-938A-82C39BA4D311};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}</ProjectTypeGuids>");
                file.WriteLine("    <Configuration Condition=\" '$(Configuration)' == '' \">Debug</Configuration>");
                file.WriteLine("    <Platform Condition=\" '$(Platform)' == '' \">x86</Platform>");
                file.WriteLine("    <OutputType>Library</OutputType>");
                file.WriteLine("    <AppDesignerFolder>Properties</AppDesignerFolder>");
                file.WriteLine("    <TargetFrameworkVersion>v4.0</TargetFrameworkVersion>");
                file.WriteLine("    <XnaFrameworkVersion>v4.0</XnaFrameworkVersion>");
                file.WriteLine("    <PlatformTarget>x86</PlatformTarget>");
                file.WriteLine("    <XNAContentPipelineTargetProfile>Reach</XNAContentPipelineTargetProfile>");
                file.WriteLine("    <OutputPath>bin\\$(Platform)\\$(Configuration)</OutputPath>");
                file.WriteLine("    <ContentRootDirectory>Content</ContentRootDirectory>");
                file.WriteLine("  </PropertyGroup>");
                file.WriteLine("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|Xbox 360' \">");
                file.WriteLine("    <XnaPlatform>x86</XnaPlatform>");
                file.WriteLine("  </PropertyGroup>");
                file.WriteLine("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|Xbox 360' \">");
                file.WriteLine("    <XnaPlatform>x86</XnaPlatform>");
                file.WriteLine("  </PropertyGroup>");
                file.WriteLine("  <PropertyGroup>");
                file.WriteLine("    <RootNamespace>ContentData</RootNamespace>");
                file.WriteLine("  </PropertyGroup>");
                file.WriteLine("  <ItemGroup>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Content.Pipeline.EffectImporter, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=MSIL\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Content.Pipeline.FBXImporter, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=MSIL\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Content.Pipeline.TextureImporter, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=MSIL\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Content.Pipeline.XImporter, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=MSIL\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Content.Pipeline.AudioImporters, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=MSIL\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("    <Reference Include=\"Microsoft.Xna.Framework.Content.Pipeline.VideoImporters, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=MSIL\">");
                file.WriteLine("      <Private>False</Private>");
                file.WriteLine("    </Reference>");
                file.WriteLine("  </ItemGroup>");
                file.WriteLine("  <ItemGroup>");
                file.WriteLine("    <ProjectReference Include=\"Xbox\\GameLibrary\\GameLibrary(Win).csproj\">");
                file.WriteLine("      <Project>{" + gameLibWGUID + "}</Project>");
                file.WriteLine("      <Name>GameLibrary(Win)</Name>");
                file.WriteLine("    </ProjectReference>");
                file.WriteLine("  </ItemGroup>");

                file.WriteLine("   <ItemGroup>");
                // Add Game Data
                FileInfo data;
                foreach (string p in Directory.GetFiles(project.Location + project.DataPath))
                {
                    data = new FileInfo(p);
                    if (data.Extension.Contains(".egm") && !data.FullName.Contains("Source.egm") && !data.FullName.Contains(Extensions.PhysQuickset))
                    {
                        file.WriteLine("     <Compile Include=\"" + data.FullName.Replace(project.Location + @"\", "") + "\">"); // Compile Include="001-Chest.png"
                        file.WriteLine("       <Name>" + Path.GetFileName(data.FullName) + "</Name>"); // <Name>001-Chest</Name>
                        file.WriteLine("       <Importer>XmlImporter</Importer>");
                        file.WriteLine("     </Compile>");
                    }
                }
                foreach (string p in Directory.GetFiles(project.Location + @"\Maps"))
                {
                    data = new FileInfo(p);
                    if (data.Extension.Contains(".egm"))
                    {
                        file.WriteLine("     <Compile Include=\"" + data.FullName.Replace(project.Location + @"\", "") + "\">"); // Compile Include="001-Chest.png"
                        file.WriteLine("       <Name>" + Path.GetFileName(data.FullName) + "</Name>"); // <Name>001-Chest</Name>
                        file.WriteLine("       <Importer>XmlImporter</Importer>");
                        file.WriteLine("     </Compile>");
                    }
                }
                data = new FileInfo(project.FullLocation);
                file.WriteLine("     <Compile Include=\"" + data.FullName.Replace(project.Location + @"\", "") + "\">"); // Compile Include="001-Chest.png"
                file.WriteLine("       <Name>" + Path.GetFileName(data.FullName) + "</Name>"); // <Name>001-Chest</Name>
                file.WriteLine("       <Importer>XmlImporter</Importer>");
                file.WriteLine("     </Compile>");
                file.WriteLine("   </ItemGroup>");

                file.WriteLine("  <Import Project=\"$(MSBuildExtensionsPath)\\Microsoft\\XNA Game Studio\\$(XnaFrameworkVersion)\\Microsoft.Xna.GameStudio.ContentPipeline.targets\" />");
                file.WriteLine("");
                file.WriteLine("  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. ");
                file.WriteLine("       Other similar extension points exist, see Microsoft.Common.targets.");
                file.WriteLine("  <Target Name=\"BeforeBuild\">");
                file.WriteLine("  </Target>");
                file.WriteLine("  <Target Name=\"AfterBuild\">");
                file.WriteLine("  </Target>");
                file.WriteLine("  -->");
                file.WriteLine("");
                file.WriteLine("</Project>");
            }
            #endregion

            path = project.Location + @"\Xbox\" + project.Name + ".sln";
            #region Solution
            using (StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine("Microsoft Visual Studio Solution File, Format Version 11.00");
                file.WriteLine("# Visual Studio 2010");
                file.WriteLine("Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"EGMGame\", \"EGMGame\\EGMGame.csproj\", \"{" + egmGameGUID + "}\"");
                file.WriteLine("EndProject");
                file.WriteLine("Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"GameLibrary\", \"GameLibrary\\GameLibrary.csproj\", \"{" + gameLibXGUID + "}\"");
                file.WriteLine("EndProject");
                file.WriteLine("Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"GameLibrary(Win)\", \"GameLibrary\\GameLibrary(Win).csproj\", \"{" + gameLibWGUID + "}\"");
                file.WriteLine("EndProject");
                file.WriteLine("Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"Content\", \"..\\Materials\\Content.contentproj\", \"{" + contentGUID + "}\"");
                file.WriteLine("EndProject");
                file.WriteLine("Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"ContentData\", \"..\\ContentData.contentproj\", \"{" + content2GUID + "}\"");
                file.WriteLine("EndProject");
                file.WriteLine("Global");
                file.WriteLine("	GlobalSection(SolutionConfigurationPlatforms) = preSolution");
                file.WriteLine("		Debug|Mixed Platforms = Debug|Mixed Platforms");
                file.WriteLine("		Debug|x86 = Debug|x86");
                file.WriteLine("		Debug|Xbox 360 = Debug|Xbox 360");
                file.WriteLine("		Release|Mixed Platforms = Release|Mixed Platforms");
                file.WriteLine("		Release|x86 = Release|x86");
                file.WriteLine("		Release|Xbox 360 = Release|Xbox 360");
                file.WriteLine("	EndGlobalSection");
                file.WriteLine("	GlobalSection(ProjectConfigurationPlatforms) = postSolution");
                file.WriteLine("		{" + egmGameGUID + "}.Debug|Mixed Platforms.ActiveCfg = Debug|Xbox 360");
                file.WriteLine("		{" + egmGameGUID + "}.Debug|Mixed Platforms.Build.0 = Debug|Xbox 360");
                file.WriteLine("		{" + egmGameGUID + "}.Debug|Mixed Platforms.Deploy.0 = Debug|Xbox 360");
                file.WriteLine("		{" + egmGameGUID + "}.Debug|x86.ActiveCfg = Debug|Xbox 360");
                file.WriteLine("		{" + egmGameGUID + "}.Debug|x86.Build.0 = Debug|Xbox 360");
                file.WriteLine("		{" + egmGameGUID + "}.Debug|Xbox 360.ActiveCfg = Debug|Xbox 360");
                file.WriteLine("		{" + egmGameGUID + "}.Debug|Xbox 360.Build.0 = Debug|Xbox 360");
                file.WriteLine("		{" + egmGameGUID + "}.Debug|Xbox 360.Deploy.0 = Debug|Xbox 360");
                file.WriteLine("		{" + egmGameGUID + "}.Release|Mixed Platforms.ActiveCfg = Release|Xbox 360");
                file.WriteLine("		{" + egmGameGUID + "}.Release|Mixed Platforms.Build.0 = Release|Xbox 360");
                file.WriteLine("		{" + egmGameGUID + "}.Release|Mixed Platforms.Deploy.0 = Release|Xbox 360");
                file.WriteLine("		{" + egmGameGUID + "}.Release|x86.ActiveCfg = Release|Xbox 360");
                file.WriteLine("		{" + egmGameGUID + "}.Release|x86.Build.0 = Release|Xbox 360");
                file.WriteLine("		{" + egmGameGUID + "}.Release|Xbox 360.ActiveCfg = Release|Xbox 360");
                file.WriteLine("		{" + egmGameGUID + "}.Release|Xbox 360.Build.0 = Release|Xbox 360");
                file.WriteLine("		{" + egmGameGUID + "}.Release|Xbox 360.Deploy.0 = Release|Xbox 360");
                file.WriteLine("		{" + gameLibXGUID + "}.Debug|Mixed Platforms.ActiveCfg = Debug|Xbox 360");
                file.WriteLine("		{" + gameLibXGUID + "}.Debug|Mixed Platforms.Build.0 = Debug|Xbox 360");
                file.WriteLine("		{" + gameLibXGUID + "}.Debug|x86.ActiveCfg = Debug|Xbox 360");
                file.WriteLine("		{" + gameLibXGUID + "}.Debug|x86.Build.0 = Debug|Xbox 360");
                file.WriteLine("		{" + gameLibXGUID + "}.Debug|Xbox 360.ActiveCfg = Debug|Xbox 360");
                file.WriteLine("		{" + gameLibXGUID + "}.Debug|Xbox 360.Build.0 = Debug|Xbox 360");
                file.WriteLine("		{" + gameLibXGUID + "}.Release|Mixed Platforms.ActiveCfg = Release|Xbox 360");
                file.WriteLine("		{" + gameLibXGUID + "}.Release|Mixed Platforms.Build.0 = Release|Xbox 360");
                file.WriteLine("		{" + gameLibXGUID + "}.Release|x86.ActiveCfg = Release|Xbox 360");
                file.WriteLine("		{" + gameLibXGUID + "}.Release|x86.Build.0 = Release|Xbox 360");
                file.WriteLine("		{" + gameLibXGUID + "}.Release|Xbox 360.ActiveCfg = Release|Xbox 360");
                file.WriteLine("		{" + gameLibXGUID + "}.Release|Xbox 360.Build.0 = Release|Xbox 360");
                file.WriteLine("		{" + gameLibWGUID + "}.Debug|Mixed Platforms.ActiveCfg = Debug|x86");
                file.WriteLine("		{" + gameLibWGUID + "}.Debug|Mixed Platforms.Build.0 = Debug|x86");
                file.WriteLine("		{" + gameLibWGUID + "}.Debug|x86.ActiveCfg = Debug|x86");
                file.WriteLine("		{" + gameLibWGUID + "}.Debug|x86.Build.0 = Debug|x86");
                file.WriteLine("		{" + gameLibWGUID + "}.Debug|Xbox 360.ActiveCfg = Debug|x86");
                file.WriteLine("		{" + gameLibWGUID + "}.Release|Mixed Platforms.ActiveCfg = Release|x86");
                file.WriteLine("		{" + gameLibWGUID + "}.Release|Mixed Platforms.Build.0 = Release|x86");
                file.WriteLine("		{" + gameLibWGUID + "}.Release|x86.ActiveCfg = Release|x86");
                file.WriteLine("		{" + gameLibWGUID + "}.Release|x86.Build.0 = Release|x86");
                file.WriteLine("		{" + gameLibWGUID + "}.Release|Xbox 360.ActiveCfg = Release|x86");
                file.WriteLine("		{" + contentGUID + "}.Debug|Mixed Platforms.ActiveCfg = Debug|x86");
                file.WriteLine("		{" + contentGUID + "}.Debug|Mixed Platforms.Build.0 = Debug|x86");
                file.WriteLine("		{" + contentGUID + "}.Debug|x86.ActiveCfg = Debug|x86");
                file.WriteLine("		{" + contentGUID + "}.Debug|x86.Build.0 = Debug|x86");
                file.WriteLine("		{" + contentGUID + "}.Debug|Xbox 360.ActiveCfg = Debug|x86");
                file.WriteLine("		{" + contentGUID + "}.Release|Mixed Platforms.ActiveCfg = Release|x86");
                file.WriteLine("		{" + contentGUID + "}.Release|Mixed Platforms.Build.0 = Release|x86");
                file.WriteLine("		{" + contentGUID + "}.Release|x86.ActiveCfg = Release|x86");
                file.WriteLine("		{" + contentGUID + "}.Release|x86.Build.0 = Release|x86");
                file.WriteLine("		{" + contentGUID + "}.Release|Xbox 360.ActiveCfg = Release|x86");
                file.WriteLine("		{" + content2GUID + "}.Debug|Mixed Platforms.ActiveCfg = Debug|x86");
                file.WriteLine("		{" + content2GUID + "}.Debug|Mixed Platforms.Build.0 = Debug|x86");
                file.WriteLine("		{" + content2GUID + "}.Debug|x86.ActiveCfg = Debug|x86");
                file.WriteLine("		{" + content2GUID + "}.Debug|x86.Build.0 = Debug|x86");
                file.WriteLine("		{" + content2GUID + "}.Debug|Xbox 360.ActiveCfg = Debug|x86");
                file.WriteLine("		{" + content2GUID + "}.Release|Mixed Platforms.ActiveCfg = Release|x86");
                file.WriteLine("		{" + content2GUID + "}.Release|Mixed Platforms.Build.0 = Release|x86");
                file.WriteLine("		{" + content2GUID + "}.Release|x86.ActiveCfg = Release|x86");
                file.WriteLine("		{" + content2GUID + "}.Release|x86.Build.0 = Release|x86");
                file.WriteLine("		{" + content2GUID + "}.Release|Xbox 360.ActiveCfg = Release|x86");
                file.WriteLine("	EndGlobalSection");
                file.WriteLine("	GlobalSection(SolutionProperties) = preSolution");
                file.WriteLine("		HideSolutionNode = FALSE");
                file.WriteLine("	EndGlobalSection");
                file.WriteLine("EndGlobal");
                file.Close();
            }
            #endregion
        }

        private static void CreateAssemblyCSEGMLIB(string p)
        {
            if (!Directory.Exists(p + @"\Properties"))
                Directory.CreateDirectory(p + @"\Properties");
            string path = p + @"\Properties\AssemblyInfo.cs";
            using (StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine("using System.Reflection;");
                file.WriteLine("using System.Runtime.CompilerServices;");
                file.WriteLine("using System.Runtime.InteropServices;");
                file.WriteLine("");
                file.WriteLine("// General Information about an assembly is controlled through the following ");
                file.WriteLine("// set of attributes. Change these attribute values to modify the information");
                file.WriteLine("// associated with an assembly.");
                file.WriteLine("[assembly: AssemblyTitle(\"GameLibrary\")]");
                file.WriteLine("[assembly: AssemblyProduct(\"GameLibrary\")]");
                file.WriteLine("[assembly: AssemblyDescription(\"\")]");
                file.WriteLine("[assembly: AssemblyCompany(\"Microsoft\")]");
                file.WriteLine("[assembly: AssemblyCopyright(\"Copyright © Microsoft 2010\")]");
                file.WriteLine("[assembly: AssemblyTrademark(\"\")]");
                file.WriteLine("[assembly: AssemblyCulture(\"\")]");
                file.WriteLine("#if WINDOWS");
                file.WriteLine("[assembly: System.Security.SecurityRules(System.Security.SecurityRuleSet.Level1, SkipVerificationInFullTrust = true)]");
                file.WriteLine("#endif");
                file.WriteLine("");
                file.WriteLine("// Setting ComVisible to false makes the types in this assembly not visible ");
                file.WriteLine("// to COM components.  If you need to access a type in this assembly from ");
                file.WriteLine("// COM, set the ComVisible attribute to true on that type. Only Windows");
                file.WriteLine("// assemblies support COM.");
                file.WriteLine("[assembly: ComVisible(false)]");
                file.WriteLine("");
                file.WriteLine("// On Windows, the following GUID is for the ID of the typelib if this");
                file.WriteLine("// project is exposed to COM. On other platforms, it unique identifies the");
                file.WriteLine("// title storage container when deploying this assembly to the device.");
                file.WriteLine("[assembly: Guid(\"412f1a80-4155-416b-be8a-ed298bafe527\")]");
                file.WriteLine("");
                file.WriteLine("// Version information for an assembly consists of the following four values:");
                file.WriteLine("//");
                file.WriteLine("//      Major Version");
                file.WriteLine("//      Minor Version ");
                file.WriteLine("//      Build Number");
                file.WriteLine("//      Revision");
                file.WriteLine("//");
                file.WriteLine("[assembly: AssemblyVersion(\"1.0.0.0\")]");
            }
        }

        private static void CreateAssemblyCSEGMGAME(string p)
        {
            if (!Directory.Exists(p + @"\Properties"))
                Directory.CreateDirectory(p + @"\Properties");
            string path = p + @"\Properties\AssemblyInfo.cs";
            using (StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine("using System.Reflection;");
                file.WriteLine("using System.Runtime.CompilerServices;");
                file.WriteLine("using System.Runtime.InteropServices;");
                file.WriteLine("");
                file.WriteLine("// General Information about an assembly is controlled through the following ");
                file.WriteLine("// set of attributes. Change these attribute values to modify the information");
                file.WriteLine("// associated with an assembly.");
                file.WriteLine("[assembly: AssemblyTitle(\"EGMGame\")]");
                file.WriteLine("[assembly: AssemblyProduct(\"EGMGame\")]");
                file.WriteLine("[assembly: AssemblyDescription(\"\")]");
                file.WriteLine("[assembly: AssemblyCompany(\"Microsoft\")]");
                file.WriteLine("[assembly: AssemblyCopyright(\"Copyright © Microsoft 2011\")]");
                file.WriteLine("[assembly: AssemblyTrademark(\"\")]");
                file.WriteLine("[assembly: AssemblyCulture(\"\")]");
                file.WriteLine("#if WINDOWS");
                file.WriteLine("[assembly: System.Security.SecurityRules(System.Security.SecurityRuleSet.Level1, SkipVerificationInFullTrust = true)]");
                file.WriteLine("#endif");
                file.WriteLine("");
                file.WriteLine("// Setting ComVisible to false makes the types in this assembly not visible ");
                file.WriteLine("// to COM components.  If you need to access a type in this assembly from ");
                file.WriteLine("// COM, set the ComVisible attribute to true on that type. Only Windows");
                file.WriteLine("// assemblies support COM.");
                file.WriteLine("[assembly: ComVisible(false)]");
                file.WriteLine("");
                file.WriteLine("// On Windows, the following GUID is for the ID of the typelib if this");
                file.WriteLine("// project is exposed to COM. On other platforms, it unique identifies the");
                file.WriteLine("// title storage container when deploying this assembly to the device.");
                file.WriteLine("[assembly: Guid(\"9380a59a-0651-491d-9331-08a0546bcb21\")]");
                file.WriteLine("");
                file.WriteLine("// Version information for an assembly consists of the following four values:");
                file.WriteLine("//");
                file.WriteLine("//      Major Version");
                file.WriteLine("//      Minor Version ");
                file.WriteLine("//      Build Number");
                file.WriteLine("//      Revision");
                file.WriteLine("//");
                file.WriteLine("[assembly: AssemblyVersion(\"1.0.0.0\")]");

            }
        }

        private static string GetProcessor(string ext)
        {
            switch (ext.ToLower())
            {
                case ".png":
                    return "TextureProcessor";
                case ".jpg":
                    return "TextureProcessor";
                case ".jpeg":
                    return "TextureProcessor";
                case ".bmp":
                    return "TextureProcessor";
                case ".mp3":
                    return "SoundEffectProcessor";
                case ".wav":
                    return "SoundEffectProcessor";
                case ".wma":
                    return "SoundEffectProcessor";
                case ".wmv":
                    return "VideoProcessor";
                case ".bmpfont":
                    return "FontTextureProcessor";
                case ".tga":
                    return "FontTextureProcessor";
                case ".fx":
                    return "EffectProcessor";
            }
            return "";
        }

        private static string GetImporter(string ext)
        {
            switch (ext.ToLower())
            {
                case ".png":
                    return "TextureImporter";
                case ".jpg":
                    return "TextureImporter";
                case ".jpeg":
                    return "TextureImporter";
                case ".bmp":
                    return "TextureImporter";
                case ".mp3":
                    return "Mp3Importer";
                case ".wav":
                    return "WavImporter";
                case ".wma":
                    return "WmaImporter";
                case ".wmv":
                    return "WmvImporter";
                case ".bmpfont":
                    return "TextureImporter";
                case ".tga":
                    return "TextureImporter";
                case ".fx":
                    return "EffectImporter";
            }
            if (ext.Contains(".egm"))
                return "XmlImporter";
            return "";
        }
    }
}
