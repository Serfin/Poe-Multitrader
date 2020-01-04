!space::
Loop
{
    	FileReadLine, line, full path to file: /users_to_whisper.txt, %A_Index%
    	if ErrorLevel
            break
    	clipboard := ""  ; Start off empty to allow ClipWait to detect when the text has arrived.
    	clipboard := line
	Send {Enter}
	Send ^v
	Send {Enter}
	Sleep 1000
}
MsgBox, The end of the file has been reached or there was a error during loading
clipboard := "" ; Clear the clipboard after work
return