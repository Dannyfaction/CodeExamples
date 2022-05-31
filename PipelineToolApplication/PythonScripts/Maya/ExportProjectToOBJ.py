import maya.standalone
maya.standalone.initialize(name='python')
import maya.cmds as cmds
import os
import sys

projectFilePath = sys.argv[1]
outputFileName = sys.argv[2]

cmds.file(projectFilePath, o=True)

currentPath = os.path.dirname(os.path.realpath(__file__))
currentPath = currentPath.replace('PythonScripts\\Maya', '')
exportSubDir = "\\MayaExports\\"
exportObjName = outputFileName + ".obj"
fullExportPath = currentPath + exportSubDir + exportObjName

try:
    os.mkdir(currentPath + "\\MayaExports")
except:
    print("folder already exists")

cmds.select(all=True)
cmds.loadPlugin('objExport') 
cmds.file(fullExportPath, pr=1, typ="OBJexport", es=1, op="groups=0; ptgroups=0; materials=0; smoothing=0; normals=0")