using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripterV2._0.Media
{
    using WindowsMediaLib;

    public class ScriptInfo : IWMHeaderInfo3
    {
        #region Implementation of IWMHeaderInfo

        void IWMHeaderInfo.GetAttributeCount(short wStreamNum, out short pcAttributes) { throw new NotImplementedException(); }

        void IWMHeaderInfo3.GetAttributeByIndex(short wIndex, ref short pwStreamNum, StringBuilder pwszName, ref short pcchNameLen, out AttrDataType pType, byte[] pValue, ref short pcbLength) { throw new NotImplementedException(); }

        void IWMHeaderInfo3.GetAttributeByName(ref short pwStreamNum, string pszName, out AttrDataType pType, byte[] pValue, ref short pcbLength) { throw new NotImplementedException(); }

        void IWMHeaderInfo3.SetAttribute(short wStreamNum, string pszName, AttrDataType Type, byte[] pValue, short cbLength) { throw new NotImplementedException(); }

        void IWMHeaderInfo3.GetMarkerCount(out short pcMarkers) { throw new NotImplementedException(); }

        void IWMHeaderInfo3.GetMarker(short wIndex, StringBuilder pwszMarkerName, ref short pcchMarkerNameLen, out long pcnsMarkerTime) { throw new NotImplementedException(); }

        void IWMHeaderInfo3.AddMarker(string pwszMarkerName, long cnsMarkerTime) { throw new NotImplementedException(); }

        void IWMHeaderInfo3.RemoveMarker(short wIndex) { throw new NotImplementedException(); }

        void IWMHeaderInfo3.GetScriptCount(out short pcScripts) { throw new NotImplementedException(); }

        void IWMHeaderInfo3.GetScript(short wIndex, StringBuilder pwszType, ref short pcchTypeLen, StringBuilder pwszCommand, ref short pcchCommandLen, out long pcnsScriptTime) { throw new NotImplementedException(); }

        void IWMHeaderInfo3.AddScript(string pwszType, string pwszCommand, long cnsScriptTime) { throw new NotImplementedException(); }

        void IWMHeaderInfo3.RemoveScript(short wIndex) { throw new NotImplementedException(); }

        void IWMHeaderInfo3.GetCodecInfoCount(out int pcCodecInfos) { throw new NotImplementedException(); }

        void IWMHeaderInfo3.GetCodecInfo(int wIndex, ref short pcchName, StringBuilder pwszName, ref short pcchDescription, StringBuilder pwszDescription, out CodecInfoType pCodecType, ref short pcbCodecInfo, byte[] pbCodecInfo) { throw new NotImplementedException(); }

        public void GetAttributeCountEx(short wStreamNum, out short pcAttributes) { throw new NotImplementedException(); }

        public void GetAttributeIndices(short wStreamNum, string pwszName, WmShort pwLangIndex, short[] pwIndices, ref short pwCount) { throw new NotImplementedException(); }

        public void GetAttributeByIndexEx(short wStreamNum, short wIndex, StringBuilder pwszName, ref short pwNameLen, out AttrDataType pType, out short pwLangIndex, byte[] pValue, ref int pdwDataLength) { throw new NotImplementedException(); }

        public void ModifyAttribute(short wStreamNum, short wIndex, AttrDataType Type, short wLangIndex, byte[] pValue, int dwLength) { throw new NotImplementedException(); }

        public void AddAttribute(short wStreamNum, string pszName, out short pwIndex, AttrDataType Type, short wLangIndex, byte[] pValue, int dwLength) { throw new NotImplementedException(); }

        public void DeleteAttribute(short wStreamNum, short wIndex) { throw new NotImplementedException(); }

        public void AddCodecInfo(string pwszName, string pwszDescription, CodecInfoType codecType, short cbCodecInfo, byte[] pbCodecInfo) { throw new NotImplementedException(); }

        void IWMHeaderInfo3.GetAttributeCount(short wStreamNum, out short pcAttributes) { throw new NotImplementedException(); }

        void IWMHeaderInfo2.GetAttributeByIndex(short wIndex, ref short pwStreamNum, StringBuilder pwszName, ref short pcchNameLen, out AttrDataType pType, byte[] pValue, ref short pcbLength) { throw new NotImplementedException(); }

        void IWMHeaderInfo2.GetAttributeByName(ref short pwStreamNum, string pszName, out AttrDataType pType, byte[] pValue, ref short pcbLength) { throw new NotImplementedException(); }

        void IWMHeaderInfo2.SetAttribute(short wStreamNum, string pszName, AttrDataType Type, byte[] pValue, short cbLength) { throw new NotImplementedException(); }

        void IWMHeaderInfo2.GetMarkerCount(out short pcMarkers) { throw new NotImplementedException(); }

        void IWMHeaderInfo2.GetMarker(short wIndex, StringBuilder pwszMarkerName, ref short pcchMarkerNameLen, out long pcnsMarkerTime) { throw new NotImplementedException(); }

        void IWMHeaderInfo2.AddMarker(string pwszMarkerName, long cnsMarkerTime) { throw new NotImplementedException(); }

        void IWMHeaderInfo2.RemoveMarker(short wIndex) { throw new NotImplementedException(); }

        void IWMHeaderInfo2.GetScriptCount(out short pcScripts) { throw new NotImplementedException(); }

        void IWMHeaderInfo2.GetScript(short wIndex, StringBuilder pwszType, ref short pcchTypeLen, StringBuilder pwszCommand, ref short pcchCommandLen, out long pcnsScriptTime) { throw new NotImplementedException(); }

        void IWMHeaderInfo2.AddScript(string pwszType, string pwszCommand, long cnsScriptTime) { throw new NotImplementedException(); }

        void IWMHeaderInfo2.RemoveScript(short wIndex) { throw new NotImplementedException(); }

        void IWMHeaderInfo2.GetCodecInfoCount(out int pcCodecInfos) { throw new NotImplementedException(); }

        void IWMHeaderInfo2.GetCodecInfo(int wIndex, ref short pcchName, StringBuilder pwszName, ref short pcchDescription, StringBuilder pwszDescription, out CodecInfoType pCodecType, ref short pcbCodecInfo, byte[] pbCodecInfo) { throw new NotImplementedException(); }

        void IWMHeaderInfo2.GetAttributeCount(short wStreamNum, out short pcAttributes) { throw new NotImplementedException(); }

        void IWMHeaderInfo.GetAttributeByIndex(short wIndex, ref short pwStreamNum, StringBuilder pwszName, ref short pcchNameLen, out AttrDataType pType, byte[] pValue, ref short pcbLength) { throw new NotImplementedException(); }

        void IWMHeaderInfo.GetAttributeByName(ref short pwStreamNum, string pszName, out AttrDataType pType, byte[] pValue, ref short pcbLength) { throw new NotImplementedException(); }

        void IWMHeaderInfo.SetAttribute(short wStreamNum, string pszName, AttrDataType Type, byte[] pValue, short cbLength) { throw new NotImplementedException(); }

        void IWMHeaderInfo.GetMarkerCount(out short pcMarkers) { throw new NotImplementedException(); }

        void IWMHeaderInfo.GetMarker(short wIndex, StringBuilder pwszMarkerName, ref short pcchMarkerNameLen, out long pcnsMarkerTime) { throw new NotImplementedException(); }

        void IWMHeaderInfo.AddMarker(string pwszMarkerName, long cnsMarkerTime) { throw new NotImplementedException(); }

        void IWMHeaderInfo.RemoveMarker(short wIndex) { throw new NotImplementedException(); }

        void IWMHeaderInfo.GetScriptCount(out short pcScripts) { throw new NotImplementedException(); }

        void IWMHeaderInfo.GetScript(short wIndex, StringBuilder pwszType, ref short pcchTypeLen, StringBuilder pwszCommand, ref short pcchCommandLen, out long pcnsScriptTime) { throw new NotImplementedException(); }

        void IWMHeaderInfo.AddScript(string pwszType, string pwszCommand, long cnsScriptTime) { throw new NotImplementedException(); }

        void IWMHeaderInfo.RemoveScript(short wIndex) { throw new NotImplementedException(); }

        #endregion
    }
}
