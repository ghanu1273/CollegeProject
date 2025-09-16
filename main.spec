# main.spec
# PyInstaller spec file for Beans Leaf Disease Detector

import sys
from PyInstaller.utils.hooks import collect_submodules

# Collect all submodules from your own packages (like "modules") and from big libs like tensorflow
hiddenimports = collect_submodules("modules") + collect_submodules("tensorflow")

block_cipher = None

a = Analysis(
    ['main2.py'],  # entry point
    pathex=[],
    binaries=[],
    datas=[
        ('modules/config.json', 'modules'),  # ✅ config.json inside modules
        ('class_labels.npy', '.'),           # labels file
        ('models', 'models'),                # models folder
        ('modules', 'modules'),              # your python package
    ],
    hiddenimports=hiddenimports,
    hookspath=[],
    hooksconfig={},
    runtime_hooks=[],
    excludes=[],
    win_no_prefer_redirects=False,
    win_private_assemblies=False,
    cipher=block_cipher,
    noarchive=False,
)

pyz = PYZ(a.pure, a.zipped_data, cipher=block_cipher)

exe = EXE(
    pyz,
    a.scripts,
    [],
    exclude_binaries=True,
    name='main',
    debug=False,
    bootloader_ignore_signals=False,
    strip=False,
    upx=True,
    console=True,   # keep console for stdout → C# can read JSON
)

coll = COLLECT(
    exe,
    a.binaries,
    a.zipfiles,
    a.datas,
    strip=False,
    upx=True,
    upx_exclude=[],
    name='main2'
)
