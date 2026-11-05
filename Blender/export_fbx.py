"""Export all meshes to FBX for Unity. Run: blender -b scene.blend -P Blender/export_fbx.py -- out.fbx"""
import sys
import bpy

out = sys.argv[sys.argv.index("--") + 1] if "--" in sys.argv else "export.fbx"
bpy.ops.export_scene.fbx(
    filepath=out,
    object_types={"MESH", "ARMATURE"},
    apply_scale_options="FBX_SCALE_ALL",
    axis_forward="-Z",
    axis_up="Y",
)
