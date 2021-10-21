#!/bin/bash
echo "Enter directory name"
read gitrepo
if [ -d "$gitrepo" ]
then
echo "Repository is exist"
else
mkdir $gitrepo
echo "Directory created"
fi

cd $gitrepo
echo "GitHub user.name"
read name
echo "GitHub user.email"
read email

git init .
git config --global user.email "$name"
git config --global user.name "$email"
touch .gitignore
git add --all
git commit -m "initial setup"

