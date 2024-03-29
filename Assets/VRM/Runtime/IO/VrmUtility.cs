﻿using System;
using System.IO;
using System.Threading.Tasks;
using UniGLTF;
using UnityEngine;
using VRMShaders;

namespace VRM
{
    public static class VrmUtility
    {
        public delegate IMaterialDescriptorGenerator MaterialGeneratorCallback(VRM.glTF_VRM_extensions vrm);
        public delegate void MetaCallback(VRMMetaObject meta);
        public static async Task<RuntimeGltfInstance> LoadAsync(string path,
            IAwaitCaller awaitCaller = null,
            MaterialGeneratorCallback materialGeneratorCallback = null,
            MetaCallback metaCallback = null
            )
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            using (GltfData data = new AutoGltfFileParser(path).Parse())
            {
                try
                {
                    var vrm = new VRMData(data);
                    IMaterialDescriptorGenerator materialGen = default;
                    if (materialGeneratorCallback != null)
                    {
                        materialGen = materialGeneratorCallback(vrm.VrmExtension);
                    }
                    using (var loader = new VRMImporterContext(vrm, materialGenerator: materialGen))
                    {
                        if (metaCallback != null)
                        {
                            var meta = await loader.ReadMetaAsync(new ImmediateCaller(), true);
                            metaCallback(meta);
                        }
                        return await loader.LoadAsync(awaitCaller);
                    }
                }
                catch (NotVrm0Exception)
                {
                    // retry
                    Debug.LogWarning("file extension is vrm. but not vrm ?");
                    using (var loader = new UniGLTF.ImporterContext(data))
                    {
                        return await loader.LoadAsync(awaitCaller);
                    }
                }
            }
        }
    }
}
