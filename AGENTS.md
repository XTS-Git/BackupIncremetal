# Decisões e fluxo de trabalho

- Manter o código no projeto principal Windows Forms, `Presentation/BackupIncremental.DeskTop`. Não investir em separação Domain/Application/Infrastructure neste momento. Código e referências de Application devem ser incorporados ao projeto principal.
- Preservar a interface Windows Forms, a integridade dos backups e a capacidade de restauração.
- Propor alterações pequenas, uma etapa por vez, e aguardar autorização antes de modificar arquivos. Preservar o código não relacionado à correção autorizada.
- Ao concluir uma etapa autorizada, validar o escopo, fazer um commit local e parar para aguardar a aprovação do usuário antes de qualquer próxima etapa.
- Trabalhar na branch `Desenv`, salvo orientação diferente do usuário.
- Não acessar nem alterar o GitHub. O usuário fará o push e abrirá as PRs quando necessário.
- Deixar a integração com OneDrive para uma etapa posterior.
