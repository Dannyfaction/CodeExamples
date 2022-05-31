import maya.standalone
maya.standalone.initialize(name='python')
import maya.cmds as cmds
import os
import sys

projectFilePath = sys.argv[1]
projectFileExtension = sys.argv[2]

cmds.file(projectFilePath, o=True)

cmds.select(all=True)
selectAll = cmds.ls(sl = True, dag = True)
for obj in selectAll:
    cmds.xform(obj, centerPivots = True)
    
cmds.file(rename=projectFilePath)

if projectFileExtension == ".mb":
    cmds.file(save=True, type="mayaBinary")
elif projectFileExtension == ".ma":
    cmds.file(save=True, type="mayaAscii")