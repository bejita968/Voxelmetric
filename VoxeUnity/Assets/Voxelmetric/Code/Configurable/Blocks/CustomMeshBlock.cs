﻿using UnityEngine;
using Voxelmetric.Code.Core;
using Voxelmetric.Code.Data_types;
using Voxelmetric.Code.Rendering.GeometryBatcher;

public class CustomMeshBlock : Block {

    public CustomMeshBlockConfig customMeshConfig { get { return (CustomMeshBlockConfig)Config; } }

    public override void BuildBlock(Chunk chunk, ref Vector3Int localPos, int materialID)
    {
        Rect texture = customMeshConfig.texture!=null
                           ? customMeshConfig.texture.GetTexture(chunk, ref localPos, Direction.down)
                           : new Rect();

        RenderGeometryBatcher batcher = chunk.GeometryHandler.Batcher;
        if (customMeshConfig.texture!=null)
            batcher.UseTextures = true;
        else
            batcher.UseColors = true;
        batcher.AddMeshData(customMeshConfig.tris, customMeshConfig.verts, ref texture, localPos, materialID);
    }
}
