function loadTheme(theme) {
    let root = document.documentElement;
    root.style.setProperty('--primary', theme.primary);
    root.style.setProperty('--primary-variant', theme.primaryVariant);
    root.style.setProperty('--secondary', theme.secondary);
    root.style.setProperty('--secondary-variant', theme.secondaryVariant);
    root.style.setProperty('--background', theme.background);
    root.style.setProperty('--surface', theme.surface);
    root.style.setProperty('--shadow', theme.shadow);
    root.style.setProperty('--error', theme.error);
    root.style.setProperty('--on-primary', theme.onPrimary);
    root.style.setProperty('--on-secondary', theme.onSecondary);
    root.style.setProperty('--on-background', theme.onBackground);
    root.style.setProperty('--on-surface', theme.onSurface);
    root.style.setProperty('--on-error', theme.onError);
};

function loadHighLight() {
    document.querySelectorAll('pre code')
        .forEach((block) => {
            hljs.highlightBlock(block);
        });
}