strFilter = "app-"
Set colGroups = GetObject("WinNT://idep")
colGroups.Filter = Array("group")
For Each objGroup In colGroups
    if lcase(mid(objGroup.Name,1,4)) = strFilter then
	'wscript.echo lcase(mid(objGroup.Name,1,4))
    	For Each objUser in objGroup.Members
        	Wscript.Echo objGroup.Name  & "," & objUser.Name
    	Next
    end if
Next
