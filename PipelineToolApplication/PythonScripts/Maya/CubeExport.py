import maya.standalone
maya.standalone.initialize(name='python')
import maya.cmds as cmds
import os
currentPath = os.path.dirname(os.path.realpath(__file__))
currentPath = currentPath.replace('PythonScripts\\Maya', '')
exportSubDir = "\\MayaExports\\"
exportObjName = "MayaTestExport.obj"
fullExportPath = currentPath + exportSubDir + exportObjName
try:
    os.mkdir(currentPath + "\\MayaExports")
except:
    print("folder already exists")
result = cmds.polyCube(w=10, h=10, d=10, name='myCube')
cmds.select(all=True)
cmds.loadPlugin('objExport') 
cmds.file(fullExportPath, pr=1, typ="OBJexport", es=1, op="groups=0; ptgroups=0; materials=0; smoothing=0; normals=0")