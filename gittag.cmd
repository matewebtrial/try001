gittag.cmd:                                     # creates tag for single directory



my $branch  = $ARGV[0];                         # branch to be tagged - mgenv_99.1-0

my $version = $ARGV[1];                         # version - 61.119-0

my $comment = $ARGV[2];                         # "Commit Comment" - "my fitst tag"

my $line;                                       

                                                

$line =  `git ls-tree HEAD | findstr $branch`;  # search tree id for branch directory

$line = ((split( " ", $line ))[2]);             # get id

#$line =  `gi t ls-tree $line | findstr src`;     # search tree id for src

#$line = ((split( " ", $line ))[2]);             # get id

$line = `git commit-tree $line -m \"$comment\"`;# create commit pointing to that id

$line = `git tag $version $line`;               # tag

$line = `git push --tags`;                      # push



#wget                                           # can get files or archive

@echo OFF

set grp=%1                                      # group - mss/scm

set prb=%2                                      # prbname 8 characters - OPKINGMX

set tag=%3                                      # branch / tag version - 61.119-0



wget --header "PRIVATE-TOKEN: %TOKEN%" https://%srv%/%grp%/%prb%/raw/%tag%/%bra%/opkingmx.inc opkingmx.inc --no-check-certificate -bqc

wget --header "PRIVATE-TOKEN: %TOKEN%" https://%srv%/%grp%/%prb%/raw/%tag%/%bra%/opkingmx.opa opkingmx.opa --no-check-certificate -bqc

wget --header "PRIVATE-TOKEN: %TOKEN%" https://%srv%/%grp%/%prb%/raw/%tag%/%bra%/opkingmx.sig opkingmx.sig --no-check-certificate -bqc

wget --header "PRIVATE-TOKEN: %TOKEN%" https://%srv%/%grp%/%prb%/raw/%tag%/%bra%/opklabmx.ftr opkingmx.ftr --no-check-certificate -bqc



wget --header "PRIVATE-TOKEN: %TOKEN%" https://gitlabe1.ext.net.nokia.com/%grp%/%prb%/repository/archive.zip?ref=%tag% -O %prb%_/%tag%/.zip --no-check-certificate -bqc

move .\%prb%\%bra\%*.* .

rmdir /s /q %prb%



#sparse pull                                    #can fetch directories subdirectories, works quite fast after initialization

@echo OFF

set grp=%1                                      # group - mss/scm

set prb=%2                                      # prbname 8 characters - OPKINGMX

set tag=%3                                      # tag version - 61.119-0

set bra=%4                                      # branch mgenv_99.1-0

set srv=gitlabe1.ext.net.nokia.com              # git server



git init >nul 2>&1                              # init empty local repo

git remote add -f origin https://%USERNAME%:%TOKEN%@%srv%/%grp%/%prb% >nul 2>&1

git config core.sparseCheckout true             # set sparse

echo /%bra% > .git/info/sparse-checkout         # set subdirectory

git pull origin %tag% >nul 2>&1

move .\%bra%\*.* .

rem rmdir /s /q .git

rmdir /s /q %bra%

del .git\index



#simple                                         #can fetch tags without loading the full repo

@echo OFF

set grp=%1

set prb=%2

set tag=%3



git init

git remote add -f origin https://%USERNAME%:%TOKEN%@%srv%/%grp%/%prb%

git pull origin %tag%

del .git\index