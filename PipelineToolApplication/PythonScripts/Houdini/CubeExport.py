import os
currentPath = os.path.dirname(os.path.realpath(__file__))
currentPath = currentPath.replace('PythonScripts\\Houdini', '')
exportSubDir = "\\HoudiniExports\\"
exportObjName = "HoudiniTestExport.obj"
fullExportPath = currentPath + exportSubDir + exportObjName
obj = hou.node("/obj")
geoNode = obj.createNode("geo", "My_Geo")
geoNode.createNode("box", "My_Box")
try:
    os.mkdir(currentPath + "\\HoudiniExports")
except:
    print("folder already exists")
hou.node('/obj/My_Geo/My_Box').geometry().saveToFile(fullExportPath)