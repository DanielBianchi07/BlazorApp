# BlazorApp
Projeto interdisciplinar da faculdade em que é utilizado Blazor para front-end conectado a uma API para back-end

# Comandos GIT

## Criar branch local e conectar com a branch remota

1- Primeiro, certifique-se de que você já tenha clonado o repositório, ou conectado ao repositorio remoto para o seu computador local usando o comando git clone.
&emsp;``git init``
&emsp;``git config --global user.name|user.email "seu nome"|"seu email"``
&emsp;``git remote add origin https://github.com/gbgelado/meu-primeiro-repositorio.git``
2- Crie uma nova branch local com o nome desejado usando o comando:\
&emsp;``git branch -b nome-da-branch``

3 - Mude para a nova branch que você criou usando o comando:\
&emsp;``git checkout nome-da-branch``

4 - vincular sua branch local com a branch remota
&emsp;``git push --set-upstream origin "nome da sua branch"``
5 - Agora, faça o push da sua nova branch local para o repositório remoto usando o comando:\
&emsp;``git add .``
&emsp;``git commit -m "mensagem de commit"``
&emsp;``git push``

O parâmetro -u (ou --set-upstream) estabelecerá a conexão entre a sua branch local e a branch remota no repositório. A partir de agora, quando você fizer git push ou git pull, o Git saberá qual branch remota está vinculada à sua branch local.

6   - Para dar merge das alterações para a main
&emsp;``git pull origin "sua branch"``
&emsp;``git checkout main``
&emsp;``git pull origin main``
&emsp;``git merge "sua branch"``
&emsp;``git push -f origin main``
