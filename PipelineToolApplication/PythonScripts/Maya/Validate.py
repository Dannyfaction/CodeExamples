import maya.standalone
maya.standalone.initialize(name='python')
import maya.cmds as cmds
import os
import sys

projectFilePath = sys.argv[1]

cmds.file(projectFilePath, o=True)

faceCount = 0

cmds.select(all=True)
selectAll = cmds.ls(sl = True, dag = True)
for obj in selectAll:
    faceCount += cmds.polyEvaluate(obj, f=True)

print(str(faceCount))