# Copyright © 2016–2017, 2019 eMedia Intellect.

# This file is part of eMI User Controls Library.

# eMI User Controls Library is free software: you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation, either version 3 of the License, or
# (at your option) any later version.

# eMI User Controls Library is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
# GNU General Public License for more details.

# You should have received a copy of the GNU General Public License
# along with eMI User Controls Library. If not, see http://www.gnu.org/licenses/.

###################################################
# Solution cleaning for eMI User Controls Library #
###################################################

Write-Host '┌─────────────────────────────────────────────────┐'
Write-Host '│ Solution cleaning for eMI User Controls Library │'
Write-Host '└─────────────────────────────────────────────────┘'
Write-Host

Write-Host 'Removing the Visual Studio solution user options directory.'
Write-Host

Remove-Item -ErrorAction 'Ignore' -Force -Path '.\.vs' -Recurse

Write-Host 'Removing the builds.'
Write-Host

Remove-Item -ErrorAction 'Ignore' -Force -Path '.\CloseableTabItem\Build' -Recurse
Remove-Item -ErrorAction 'Ignore' -Force -Path '.\CloseableTabItemTesting\Build' -Recurse
Remove-Item -ErrorAction 'Ignore' -Force -Path '.\FileSystemBrowserWindow\Build' -Recurse
Remove-Item -ErrorAction 'Ignore' -Force -Path '.\FileSystemBrowserWindowTesting\Build' -Recurse