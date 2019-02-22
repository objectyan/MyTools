namespace WebDataService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SPIInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.SIInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // SPIInstaller
            // 
            this.SPIInstaller.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.SPIInstaller.Password = null;
            this.SPIInstaller.Username = null;
            // 
            // SIInstaller
            // 
            this.SIInstaller.ServiceName = "Service1";
            this.SIInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.SPIInstaller,
            this.SIInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller SPIInstaller;
        private System.ServiceProcess.ServiceInstaller SIInstaller;
    }
}