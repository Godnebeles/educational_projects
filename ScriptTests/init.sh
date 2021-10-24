#!/bin/bash
echo "Enter directory name"
read gitrepo
if [ -d "$gitrepo" ]
then
cd $gitrepo
echo "You chose this directory: "
echo $PWD
else
mkdir $gitrepo
echo "Directory not exist, created new dir \"$gitrepo\""
echo $PWD
cd $gitrepo
fi

echo "GitHub user.name"
read name
echo "GitHub user.email"
read email

echo "* text=auto" > .gitattributes
git init .
git config --global user.email "$name"
git config --global user.name "$email"
touch .gitignore
git add --all
git commit -m "initial setup"

